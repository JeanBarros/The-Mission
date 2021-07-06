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
    public class Player : Motion
    {
        private Weapon equippedWeapon;

        private Random random = new Random();

        public int HitPoints { get; private set; }

        private List<Weapon> inventory = new List<Weapon>();        
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location, Canvas boundaries, Rectangle player)
            : base(game, location)
        {
            HitPoints = 10;

            // Creates the player into stage
            player.Tag = "player";
            player.Width = 80;
            player.Height = 103;
            //player.Margin = new Thickness(10);
            //player.StrokeThickness = 2;
            ImageBrush playerTexture = new ImageBrush();
            playerTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/player.png"));
            player.Fill = playerTexture;

            // Sets a player random position
            Canvas.SetLeft(player, random.Next(10, 434));
            Canvas.SetTop(player, random.Next(10, 270));
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                    equippedWeapon = weapon;
            }
        }

        public void Move(Rectangle playerBox, Direction direction)
        {
            base.location = Move(playerBox, direction, game.Boundaries);
            //if (!game.WeaponInRoom.PickedUp)
            //{
            //    // see if the weapon is nearby, and possibly pick it up
            //}
        }

        public void Attack(Direction direction, Random random)
        {

        }
    }
}
