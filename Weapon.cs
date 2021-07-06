using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace The_Mission
{
    public abstract class Weapon : Motion
    {
        public bool PickedUp { get; private set; }

        public Weapon(Game game, Point location)
            :base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            //Point target = game.PlayerLocation;

            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                //target = Move(direction, game.Boundaries);
            }
            return false;
        }
    }
}
