using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace The_Mission
{
    public abstract class Motion
    {
        private const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;
        protected Weapon weapon;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public Motion(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        /// <summary>
        /// Checks if a enemy is within weapon range (radius). If they’re within distance of each other, then it returns true; otherwise, it returns false.
        /// </summary>
        /// <param name="stage"></param>
        /// <param name="playerBox"></param>
        /// <param name="distance"></param>
        /// /// <param name="isPlayerAttacking"></param>
        /// <returns></returns>
        public bool Nearby(Canvas stage, Rectangle playerBox, Rectangle batBox, int distance, bool isPlayerAttacking)
        {
            // HitBox creates a box outside of the objects (bounds) which will be used to detect collision between two objects
            // Sword hit box needs to collide with Bat hit box using IntersectsWith method, which means the Bat is within sword range (radius).
            
            Rect playerHitBox = new Rect(Canvas.GetLeft(playerBox), Canvas.GetTop(playerBox), (playerBox.Width), playerBox.Height);
            Rect batHitBox;

            foreach (var item in stage.Children.OfType<Rectangle>())
            {
                // Checks if the move is player's attack or an enemy's attack.
                if (isPlayerAttacking)
                {
                    if ((string)item.Tag == "Bat")
                    {
                        if (stage.Children.Contains(playerBox))
                        {
                            batHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                            if (playerHitBox.IntersectsWith(batHitBox))
                            {
                                MessageBox.Show($"{item.Tag} says: Ouch!");

                                return true;
                            }
                        }
                    }
                }
                else
                {
                    if ((string)item.Tag == "Player")
                    {
                        if (stage.Children.Contains(batBox))
                        {
                            playerHitBox = new Rect(Canvas.GetLeft(playerBox), Canvas.GetTop(playerBox), (playerBox.Width), (playerBox.Height));
                            batHitBox = new Rect(Canvas.GetLeft(batBox), Canvas.GetTop(batBox), batBox.Width, batBox.Height);

                            if (batHitBox.IntersectsWith(playerHitBox))
                            {
                                MessageBox.Show($"{item.Tag} says: Ouch!");
                                return true;
                            }
                        }
                    }
                }
            }
            
            return false;
        }

        /// <summary>
        /// Moves the CHARACTERS to a DIRECTION within the LIMITS of the dungeon. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="direction"></param>
        /// <param name="boundaries"></param>
        /// <returns></returns>
        public Point Move(Rectangle character, Direction direction, Canvas boundaries)
        {
            Point newLocation = location;

            switch (direction)
            {
                case Direction.Up:
                    if (Canvas.GetTop(character) > 10)
                    {
                        Canvas.SetTop(character, newLocation.Y -= MoveInterval);
                    }
                    break;
                case Direction.Down:
                    if ((Canvas.GetTop(character) + character.Height) < (boundaries.ActualHeight - MoveInterval))
                    {
                        Canvas.SetTop(character, newLocation.Y += MoveInterval);
                    }
                    break;
                case Direction.Left:
                    if (Canvas.GetLeft(character) > 0)
                    {
                        Canvas.SetLeft(character, newLocation.X -= MoveInterval);

                        if (Canvas.GetLeft(character) < 0)
                        {
                            Canvas.SetLeft(character, newLocation.X + MoveInterval);
                        }
                    }
                    break;
                case Direction.Right:
                    if ((Canvas.GetLeft(character) + character.Width) < (boundaries.ActualWidth - MoveInterval))
                    {
                        Canvas.SetLeft(character, newLocation.X += MoveInterval);
                    }

                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
