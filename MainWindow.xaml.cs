using System;
using System.Collections.Generic;
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

            int score = 0;

            lblPlayer.Content = "Player: " + score;
            lblEnemy1.Content = "Bat: ";
            lblEnemy2.Content = "Ghost: ";
            lblEnemy3.Content = "Zombie: ";

            game = new Game(Stage, playerBox);
            game.NewLevel(batBox, swordBox);
        }

        public void UpdateCharacters()
        {
            //Player.Location = game.PlayerLocation;
            //playerHitPoints.Text =
            //game.PlayerHitPoints.ToString();
            //bool showBat = false;
            //bool showGhost = false;
            //bool showGhoul = false;
            //int enemiesShown = 0;

            //foreach (Enemy enemy in game.Enemies)
            //{
            //    if (enemy is Bat)
            //    {
            //        bat.Location = enemy.Location;
            //        batHitPoints.Text = enemy.HitPoints.ToString();
            //        if (enemy.HitPoints > 0)
            //        {
            //            showBat = true;
            //            enemiesShown++;
            //        }
            //    }
            //}
        }

        private void btnMoveUp_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, Motion.Direction.Up, random);
            UpdateCharacters();
        }

        private void btnMoveRight_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, Motion.Direction.Right, random);
            UpdateCharacters();
        }

        private void btnMoveDown_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, Motion.Direction.Down, random);
            UpdateCharacters();
        }

        private void btnMoveLeft_Click(object sender, RoutedEventArgs e)
        {
            game.Move(playerBox, Motion.Direction.Left, random);
            UpdateCharacters();
        }
    }
}
