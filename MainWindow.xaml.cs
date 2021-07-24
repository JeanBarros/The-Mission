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
        public MainWindow()
        {
            InitializeComponent();

            game = new Game(Stage, playerBox, swordIcon);
            game.NewLevel(batBox, swordBox);
            UpdateCharacters();
        }

        public void UpdateCharacters()
        {
            playerHitPoints.Content = $"Player: {game.PlayerHitPoints.ToString()}";
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batHitPoints.Content = $"Bat: {enemy.HitPoints.ToString()}";
                    if (enemy.Dead)
                    {
                        showBat = false;
                        //MessageBox.Show($"{enemy.Name} died!");
                        //batBox.Visibility = Visibility.Hidden;
                        Stage.Children.Remove(batBox);
                        batHitPoints.Content = $"Bat is dead!";
                    }
                    else
                    {
                        showBat = true;
                        enemiesShown++;
                    }
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
            }

            // Weapons in Room
            Rectangle weaponControl = null;

            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = swordBox;
                    break;
            }            

            //weaponControl.Visibility = Visibility.Visible;

            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visibility = Visibility.Hidden;
                swordIcon.Visibility = Visibility.Visible;
                game.Equip(weaponControl.Name);
            }
            else
                weaponControl.Visibility = Visibility.Visible;
        }

        #region Moves
        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Up, random);
            UpdateCharacters();
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Right, random);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Down, random);
            UpdateCharacters();
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, batBox, Motion.Direction.Left, random);
            UpdateCharacters();
        }
        #endregion

        #region Attack
        private void btnAttackUp_Click(object sender, RoutedEventArgs e)
        {
            game.Attack(Stage, playerBox, batBox, Motion.Direction.Up, random);
            UpdateCharacters();
        }

        #endregion
    }
}
