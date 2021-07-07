using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace The_Mission
{
    class Sword : Weapon
    {
        private Rectangle sword;

        public Sword(Game game, Rectangle swordBox)
            :base(game) 
        {
            // Creates the bat into stage
            sword = swordBox;
            sword.Tag = "sword";
            sword.Width = 70;
            sword.Height = 52;
            //player.Margin = new Thickness(10);
            //player.StrokeThickness = 2;
            ImageBrush swordTexture = new ImageBrush();
            swordTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/sword.png"));
            sword.Fill = swordTexture;

            // Sets a bat random position
            game.GetRandomLocation(sword); 
        }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random)
        {
            // Your code goes here
        }
    }
}
