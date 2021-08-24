using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace The_Mission
{
    class GreenPotion : Weapon
    {
        public override string Name { get { return "Green Potion"; } }

        public GreenPotion(Game game, Canvas stage, Rectangle greenPotionBox, Point location)
            :base(game, location)
        {
            // Since Potion is created on a random location, this will set the collision box on the right bat position.
            foreach (var item in stage.Children.OfType<Rectangle>())
            {
                if ((string)item.Tag == "greenPotionBoxCollider")
                {
                    greenPotionBoxCollider = item;

                    Canvas.SetLeft(item, Canvas.GetLeft(greenPotionBox) + item.Width / 4);
                    Canvas.SetTop(item, Canvas.GetTop(greenPotionBox) + item.Height / 2);
                }
            }
        }

        public override void Attack(Canvas stage, Rectangle playerBox, Rectangle batBox, Direction direction, Random random, string weaponName)
        {
            throw new NotImplementedException();
        }
    }
}
