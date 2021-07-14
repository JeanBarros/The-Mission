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
        //protected Point location;
        //public Point Location { get { return location; } }
        protected Game game;
        protected Weapon weapon;

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

        public bool Nearby(Canvas stage, Rectangle playerBox, int distance)
        {
            // HitBox creates a box outside of the objects (bounds) which will be used to detect collision between two objects
            // Sword hit box needs to collide with Bat hit box using IntersectsWith method, which means the Bat is within sword range (radius).
            
            Rect playerHitBox = new Rect(Canvas.GetLeft(playerBox), Canvas.GetTop(playerBox), (playerBox.Width), (playerBox.Height));

            foreach (var item in stage.Children.OfType<Rectangle>())
            {
                if ((string)item.Tag == "Bat")
                {
                    Rect batHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                    if (playerHitBox.IntersectsWith(batHitBox))
                    {
                        MessageBox.Show("Bat says: Ouch!");
                        return true;
                    }
                    
                }
            }
            
            return false;
        }

        /// <summary>
        /// Moves the PLAYER to a DIRECTION within the LIMITS of the dungeon. 
        /// </summary>
        /// <param name="playerBox"></param>
        /// <param name="direction"></param>
        /// <param name="boundaries"></param>
        /// <returns></returns>
        public void Move(Rectangle playerBox, Direction direction, Canvas boundaries)
        {
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
        }
    }
}
