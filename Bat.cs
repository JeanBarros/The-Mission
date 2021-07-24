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

        public Bat(Game game, Rectangle batBox)
            : base(game, 6)
        {
            // Creates the bat into stage
            bat = batBox;
            bat.Tag = "Bat";
            bat.Width = 50;
            bat.Height = 50;
            //player.Margin = new Thickness(10);
            //player.StrokeThickness = 2;
            ImageBrush batTexture = new ImageBrush();
            batTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/bat.png"));
            bat.Fill = batTexture;

            // Sets a bat random position
            // game.GetRandomLocation(bat);            
        }

        public override void Move(Canvas stage, Rectangle playerBox, Rectangle batBox, Random random)
        {
            // Sets a bat random position
            Canvas.SetLeft(bat, random.Next(10, 434));
            Canvas.SetTop(bat, random.Next(10, 270));

            if (NearPlayer(stage, playerBox, batBox))
            {
                game.HitPlayer(2, random);
            }            
        }
    }
}
