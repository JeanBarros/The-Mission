using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using static The_Mission.Motion;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace The_Mission
{
    public class Game
    {
        private Player player;
        private Random random = new Random();

        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        //public Point PlayerLocation { get { return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }
        private int level = 0;
        public int Level { get { return level; } }

        private Canvas boundaries;
        public Canvas Boundaries
        {
            get { return boundaries; }
        }

        public Game(Canvas boundaries, Rectangle playerBox, Rectangle swordIcon)
        {
            this.boundaries = boundaries;

            player = new Player(this, playerBox);

            // Sets a position to spawn the player in the dungeon.
            //Canvas.SetLeft(playerBox, 0);
            //Canvas.SetTop(playerBox, boundaries.Height / 2);
        }

        /// <summary>
        /// Moves the PLAYER to a specific DIRECTION and then moves the enemy in another one RANDOM.
        /// </summary>
        /// <param name="playerBox"></param>
        /// <param name="direction"></param>
        /// <param name="random"></param>
        public void Move(Rectangle playerBox, Direction direction, Random random)
        {
            player.Move(boundaries, playerBox, direction);

            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Canvas stage, Rectangle playerBox, Direction direction, Random random)
        {
            player.Attack(stage, playerBox, direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        public void GetRandomLocation(Rectangle character)
        {
            // Sets a character random position
            Canvas.SetLeft(character, random.Next(10, 434));
            Canvas.SetTop(character, random.Next(10, 270));
        }

        public void NewLevel(Rectangle batBox, Rectangle swordBox)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>() {
                        new Bat(this, batBox),
                    };
                    WeaponInRoom = new Sword(this, swordBox);
                    break;
                default:
                    break;
            }
        }
    }
}
