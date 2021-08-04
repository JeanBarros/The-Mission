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
    class Bat : Enemy
    {
        private readonly Rectangle bat;

        public override string Name { get { return "Bat"; } }

        public Bat(Game game, Rectangle batBox, Point location)
            : base(game, 6, location)
        {
            //Creates the bat into stage dinamically
            //bat = batBox;
            //bat.Tag = "Bat";
            //bat.Width = 50;
            //bat.Height = 50;
            //ImageBrush batTexture = new ImageBrush();
            //batTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/bat.png"));
            //bat.Fill = batTexture;

            //Stage.Children.Add(batBox);
        }

        public override void Move(Canvas stage, Rectangle playerBox, Rectangle batBox, Random random, Point playerLocation)
        {
            // Bat moves 50% randomly and 50% toward player direction
            int[] options = new int[] { 0, 1 };
            int index = random.Next(options.Length);
            Console.WriteLine(options[index]);

            if (options[index] == 0)
            {
                Direction direction = FindPlayerDirection(playerLocation);
                location = Move(batBox, direction, game.Boundaries);
            }
            else
            {
                // Sets a bat random position
                Canvas.SetLeft(batBox, random.Next(10, 434) / 10 * 10);
                Canvas.SetTop(batBox, random.Next(10, 270) / 10 * 10);
            }

            if (NearPlayer(stage, playerBox, batBox))
            {
                game.HitPlayer(2, random);
            }
        }
    }
}
