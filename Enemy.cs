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
    public abstract class Enemy : Motion
    {
        private const int NearPlayerDistance = 25;

        public int HitPoints { get; private set; }
        public bool Dead
        {
            get
            {
                if (HitPoints <= 0) 
                    return true;
                else 
                    return false;
            }
        }

        public abstract string Name { get; }

        public Enemy(Game game, int hitPoints, Point location)
        : base(game, location)
        {
            HitPoints = hitPoints;
        }

        public abstract void Move(Canvas stage, Rectangle playerBox, Rectangle batBox, Random random, Point playerLocation);

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        protected bool NearPlayer(Canvas stage, Rectangle playerBox, Rectangle batBox)
        {
            return Nearby(stage, playerBox, batBox, NearPlayerDistance, false);
        }

        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;

            if (playerLocation.X > location.X + 10)
            {
                directionToMove = Direction.Right;
            }
            else if (playerLocation.X < location.X - 10)
            {
                directionToMove = Direction.Left;
            }
            else if (playerLocation.Y < location.Y - 10)
            {
                directionToMove = Direction.Up;
            }
            else
            {
                directionToMove = Direction.Down;
            }

            return directionToMove;
        }
    }
}
