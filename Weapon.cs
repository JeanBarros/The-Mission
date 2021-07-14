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
    public abstract class Weapon : Motion
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game)
            :base(game)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Canvas stage, Rectangle playerBox, Direction direction, Random random, string weaponName);

        protected bool DamageEnemy(Canvas stage, Rectangle playerBox, Direction direction, int radius, int damage, Random random)
        {
            //Point target = game.PlayerLocation;

            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(stage, playerBox, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }

                    //MessageBox.Show(enemy.Name);
                }
                
                //target = Move(direction, game.Boundaries);
            }
            return false;
        }
    }
}
