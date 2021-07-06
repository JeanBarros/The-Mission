using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace The_Mission
{
    public abstract class Motion
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Motion(Game game/*, Point location*/)
        {
            this.game = game;
            //this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            //if (Math.Abs(location.X - locationToCheck.X) < distance &&
            //(Math.Abs(location.Y - locationToCheck.Y) < distance))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// Moves the PLAYER to a DIRECTION within the LIMITS of the dungeon. 
        /// </summary>
        /// <param name="playerBox"></param>
        /// <param name="direction"></param>
        /// <param name="boundaries"></param>
        /// <returns></returns>
        public Point Move(Rectangle playerBox, Direction direction, Canvas boundaries)
        {
            Point newLocation = location;
            switch (direction)
            {
                case Direction.Up:
                    if (Canvas.GetTop(playerBox) > 10)
                    {
                        Canvas.SetTop(playerBox, Canvas.GetTop(playerBox) - MoveInterval);
                    }
                    break;
                case Direction.Down:
                    if ((Canvas.GetTop(playerBox) + (playerBox.Height)) < (boundaries.ActualHeight - MoveInterval))
                    {
                        Canvas.SetTop(playerBox, Canvas.GetTop(playerBox) + MoveInterval);
                    }
                    break;
                case Direction.Left:
                    if (Canvas.GetLeft(playerBox) > 0)
                    {
                        Canvas.SetLeft(playerBox, Canvas.GetLeft(playerBox) - MoveInterval);

                        if (Canvas.GetLeft(playerBox) < 0)
                        {
                            Canvas.SetLeft(playerBox, Canvas.GetLeft(playerBox) + MoveInterval);
                        }
                    }
                    break;
                case Direction.Right:
                    if ((Canvas.GetLeft(playerBox) + (playerBox.Width)) < (boundaries.ActualWidth - MoveInterval))
                    {
                        Canvas.SetLeft(playerBox, Canvas.GetLeft(playerBox) + MoveInterval);
                    }
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
