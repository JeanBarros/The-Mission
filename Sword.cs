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
                    Canvas.SetLeft(item, Canvas.GetLeft(swordBox) + item.Width / 4);
                    Canvas.SetTop(item, Canvas.GetTop(swordBox) + item.Height / 2);
                }
            }
        }

        public override void Attack(Canvas stage, Rectangle playerBox, Rectangle batBox, Direction direction, Random random, string weaponName)
        {
            //MessageBox.Show($"Attack in {direction} direction using a {weaponName}!");
            DamageEnemy(stage, playerBox, batBox, direction, 10, 3, random);
        }
    }
}
