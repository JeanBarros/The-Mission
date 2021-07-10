﻿using System;
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
        private Rectangle player;
        private Weapon equippedWeapon;

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

        public Player(Game game, Rectangle playerBox)
            : base(game)
        {
            HitPoints = 10;

            // Creates the player into stage
            player = playerBox;
            player.Tag = "player";
            player.Width = 80;
            player.Height = 103;
            //player.Margin = new Thickness(10);
            //player.StrokeThickness = 2;
            ImageBrush playerTexture = new ImageBrush();
            playerTexture.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/Images/player.png"));
            player.Fill = playerTexture;
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

        public void Move(Canvas stage, Rectangle playerBox, Direction direction)
        {
            Move(playerBox, direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                // HitBox creates a box outside of the objects (bounds) which will be used to detect collision between two objects
                // Divides width and height of the player by two only to make sure that he will pick up the weapon when closest of it.
                Rect playerHitBox = new Rect(Canvas.GetLeft(playerBox), Canvas.GetTop(playerBox), (playerBox.Width / 2), (playerBox.Height / 2));

                foreach (var item in stage.Children.OfType<Rectangle>())
                {
                    if ((string)item.Tag == "Sword")
                    {
                        Rect weaponHitBox = new Rect(Canvas.GetLeft(item), Canvas.GetTop(item), item.Width, item.Height);
                        if (playerHitBox.IntersectsWith(weaponHitBox))
                        {
                            MessageBox.Show("Weapon Picked");
                            game.WeaponInRoom.PickUpWeapon();
                            inventory.Add(game.WeaponInRoom);
                        }
                    }
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {

        }
    }
}
