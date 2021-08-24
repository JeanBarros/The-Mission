using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace The_Mission
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;
        private Random random = new Random();
        Point playerLocation, batLocation;

        public MainWindow()
        {
            InitializeComponent();

            game = new Game(Stage, playerBox, swordIcon);
            game.NewLevel(batBox, swordBox, greenPotionBox, random);
            UpdateCharacters();            
        }

        public void UpdateCharacters()
        {
            playerLocation = game.PlayerLocation;
            
            playerHitPoints.Content = $"Player: {game.PlayerHitPoints.ToString()}";
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batLocation = enemy.Location;
                    batHitPoints.Content = $"Bat: {enemy.HitPoints.ToString()}";

                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }

                    //if (enemy.Dead)
                    //{
                    //    showBat = false;
                    //    //MessageBox.Show($"{enemy.Name} died!");
                    //    //batBox.Visibility = Visibility.Hidden;
                    //    Stage.Children.Remove(batBox);
                    //    Stage.Children.Remove(batBoxCollider);
                    //    batHitPoints.Content = $"Bat is dead!";
                    //}
                    //else
                    //{
                    //    showBat = true;
                    //    enemiesShown++;
                    //}
                }

                swordBox.Visibility = Visibility.Hidden;
                greenPotionBox.Visibility = Visibility.Hidden;
                //bow.Visibility = Visibility.Hidden;
                //bluePotion.Visibility = Visibility.Hidden;
                //mace.Visibility = Visibility.Hidden;

                // Weapons in Room
                Rectangle weaponControl = null;

                switch (game.WeaponInRoom.Name)
                {
                    case "Sword":
                        weaponControl = swordBox;
                        break;
                    case "Green Potion":
                        weaponControl = greenPotionBox;
                        break;
                }

                weaponControl.Visibility = Visibility.Visible;

                if (game.WeaponInRoom.PickedUp)
                {
                    weaponControl.Visibility = Visibility.Hidden;
                    //game.Equip(weaponControl.Name);
                }
                else
                {
                    weaponControl.Visibility = Visibility.Visible;
                }

                if (game.PlayerHitPoints <= 0)
                {
                    Stage.Children.Remove(playerBox);
                    playerHitPoints.Content = $"Player is dead!";
                }
            }

            // If the weapon is the only one that the player has, equip it immediately.
            if (game.PlayerWeapons.Count() == 1)
            {
                game.Equip(game.PlayerWeapons.First());
            }

            if (game.CheckPlayerInventory("Sword"))
            {
                game.Equip("Sword");
                swordIcon.StrokeThickness = 2;
                swordIcon.Stroke = Brushes.White;
                swordIcon.Visibility = Visibility.Visible;
                //Stage.Children.Remove(swordBoxCollider);
            }
            if (game.CheckPlayerInventory("GreenPotion"))
            {
                greenPotionIcon.StrokeThickness = 2;
                greenPotionIcon.Stroke = Brushes.White;
                greenPotionIcon.Visibility = Visibility.Visible;
            }

            if (enemiesShown < 1)
            {
                if (game.Level < 3)
                {
                    MessageBox.Show("You have defeated the enemies on this level");
                    game.NewLevel(batBox, swordBox, greenPotionBox, random);
                    UpdateCharacters();
                }
            }
        }

        #region Moves
        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Up, random, playerLocation);
            UpdateCharacters();
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Right, random, playerLocation);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Down, random, playerLocation);
            UpdateCharacters();
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Left, random, playerLocation);
            UpdateCharacters();
        }
        #endregion

        #region Attack
        private void BtnAttackUp_Click(object sender, RoutedEventArgs e)
        {
            game.Attack(Stage, playerBox, batBox, Motion.Direction.Up, random, playerLocation);
            UpdateCharacters();
        }
        private void BtnAttackDown_Click(object sender, RoutedEventArgs e)
        {
            game.Attack(Stage, playerBox, batBox, Motion.Direction.Down, random, playerLocation);
            UpdateCharacters();
        }
        private void BtnAttackLeft_Click(object sender, RoutedEventArgs e)
        {
            game.Attack(Stage, playerBox, batBox, Motion.Direction.Left, random, playerLocation);
            UpdateCharacters();
        }

        private void BtnAttackRight_Click(object sender, RoutedEventArgs e)
        {
            game.Attack(Stage, playerBox, batBox, Motion.Direction.Right, random, playerLocation);
            UpdateCharacters();
        }

        #endregion

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            #region Moves using keyboard
            if (e.Key == Key.Up)
            {
                game.Move(playerBox, batBox, Motion.Direction.Up, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.Down)
            {
                game.Move(playerBox, batBox, Motion.Direction.Down, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.Left)
            {
                game.Move(playerBox, batBox, Motion.Direction.Left, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.Right)
            {
                game.Move(playerBox, batBox, Motion.Direction.Right, random, playerLocation);
                UpdateCharacters();
            }
            #endregion

            #region Attack using keyboard
            if (e.Key == Key.NumPad8)
            {
                game.Attack(Stage, playerBox, batBox, Motion.Direction.Up, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.NumPad2)
            {
                game.Attack(Stage, playerBox, batBox, Motion.Direction.Down, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.NumPad4)
            {
                game.Attack(Stage, playerBox, batBox, Motion.Direction.Left, random, playerLocation);
                UpdateCharacters();
            }
            if (e.Key == Key.NumPad6)
            {
                game.Attack(Stage, playerBox, batBox, Motion.Direction.Right, random, playerLocation);
                UpdateCharacters();
            }
            #endregion
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }
    }
}
