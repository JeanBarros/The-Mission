using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace The_Mission
{
    class Sword : Weapon
    {
        public override string Name { get { return "Sword"; } }
        public Sword(Game game, Canvas stage, Rectangle swordBox, Point location)
            : base(game, location)
        {
            // Since Sword is created on a random location, this will set the collision box on the right bat position.
            foreach (var item in stage.Children.OfType<Rectangle>())
            {
                if ((string)item.Tag == "swordBoxCollider")
                {
                    swordBoxCollider = item;

                    Canvas.SetLeft(item, Canvas.GetLeft(swordBox) + item.Width / 4);
                    Canvas.SetTop(item, Canvas.GetTop(swordBox) + item.Height / 2);
                }
            }
        }

        public override void Attack(Canvas stage, Rectangle playerBox, Rectangle batBox, Direction direction, Random random, string weaponName)
        {
            foreach (var item in stage.Children.OfType<Rectangle>())
            {
                if ((string)item.Tag == "playerBoxCollider")
                {
                    playerBoxCollider = item;
                }
                if ((string)item.Tag == "batBoxCollider")
                {
                    batBoxCollider = item;
                }

                // Size and position of the Sword Box Collider will be changed after player's attack
                if ((string)item.Tag == "Sword")
                {
                    switch (direction)
                    {
                        case Direction.Up:
                            swordBoxCollider.Width *= 2;
                            Canvas.SetTop(swordBoxCollider, Canvas.GetTop(playerBoxCollider) - swordBoxCollider.Height);
                            Canvas.SetLeft(swordBoxCollider, Canvas.GetLeft(playerBoxCollider) - (playerBoxCollider.Width - swordBoxCollider.Width) / 2 * -1);
                            break;
                        case Direction.Down:
                            swordBoxCollider.Width *= 2;
                            swordBoxCollider.Height /= 2;
                            Canvas.SetTop(swordBoxCollider, Canvas.GetTop(playerBoxCollider) + playerBoxCollider.Height);
                            Canvas.SetLeft(swordBoxCollider, Canvas.GetLeft(playerBoxCollider) - (playerBoxCollider.Width - swordBoxCollider.Width) / 2 * -1);
                            break;
                        case Direction.Left:
                            swordBoxCollider.Width /= 1.5;
                            swordBoxCollider.Height *= 2.5;
                            Canvas.SetLeft(swordBoxCollider, Canvas.GetLeft(playerBoxCollider) - swordBoxCollider.Width);
                            Canvas.SetTop(swordBoxCollider, Canvas.GetTop(playerBoxCollider) - (playerBoxCollider.Height - swordBoxCollider.Height) / 2 * -1);
                            break;
                        case Direction.Right:
                            swordBoxCollider.Width /= 1.5;
                            swordBoxCollider.Height *= 2.5;
                            Canvas.SetLeft(swordBoxCollider, Canvas.GetLeft(playerBoxCollider) + playerBoxCollider.Width);
                            Canvas.SetTop(swordBoxCollider, Canvas.GetTop(playerBoxCollider) - (playerBoxCollider.Height - swordBoxCollider.Height) / 2 * -1);
                            break;
                        default:
                            break;
                    }

                    // Use a border and message box to see the size and position of the Sword Box Collider by changing.
                    // MessageBox.Show($"Attack in {direction} direction using a {weaponName}!");

                    swordHitBox = new Rect(Canvas.GetLeft(swordBoxCollider), Canvas.GetTop(swordBoxCollider), swordBoxCollider.Width, swordBoxCollider.Height);
                    batHitBox = new Rect(Canvas.GetLeft(batBoxCollider), Canvas.GetTop(batBoxCollider), batBoxCollider.Width, batBoxCollider.Height);

                    _ = DamageEnemy(stage, playerBox, batBox, direction, 10, 3, random);
                }
            }

            // Resets the Sword Box Collider to the center of the Player Box Collider after player's attack
            swordBoxCollider.Width = 40;
            swordBoxCollider.Height = 30;

            Canvas.SetLeft(swordBoxCollider, Canvas.GetLeft(playerBoxCollider));
            Canvas.SetTop(swordBoxCollider, Canvas.GetTop(playerBoxCollider) + (playerBoxCollider.Height - swordBoxCollider.Height) / 2);
        }
    }
}