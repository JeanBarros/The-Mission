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
        private Rectangle bat;
        private Random random = new Random(); 
        
        public Bat(Game game, Point location, Rectangle batBox)
            : base(game, 6)
        {
            // Creates the bat into stage
            bat = batBox;
            bat.Tag = "bat";
            bat.Width = 50;
            bat.Height = 50;
            //player.Margin = new Thickness(10);
            //player.StrokeThickness = 2;
            ImageBrush playerTexture = new ImageBrush();
            playerTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/bat.png"));
            bat.Fill = playerTexture;

            // Sets a bat random position
            Canvas.SetLeft(bat, random.Next(10, 434));
            Canvas.SetTop(bat, random.Next(10, 270));
        }

        public override void Move(Random random)
        {
            // Sets a bat random position
            Canvas.SetLeft(bat, random.Next(10, 434));
            Canvas.SetTop(bat, random.Next(10, 270));
        }
    }
}
