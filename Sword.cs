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
    class Sword : Weapon
    {
        private readonly Rectangle sword;

        public override string Name { get { return "Sword"; } }
        public Sword(Game game, Rectangle swordBox, Point location)
            : base(game, location)
        {
            // Creates the sword into stage dynamically
            //sword = swordBox;
            //sword.Tag = "Sword";
            //sword.Width = 70;
            //sword.Height = 52;
            ////player.Margin = new Thickness(10);
            ////player.StrokeThickness = 2;
            //ImageBrush swordTexture = new ImageBrush();
            //swordTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/sword.png"));
            //sword.Fill = swordTexture;                       
        }

        public override void Attack(Canvas stage, Rectangle playerBox, Rectangle batBox, Direction direction, Random random, string weaponName)
        {
            //MessageBox.Show($"Attack in {direction} direction using a {weaponName}!");
            DamageEnemy(stage, playerBox, batBox, direction, 10, 3, random);
        }
    }
}
