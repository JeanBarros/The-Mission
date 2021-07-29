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
        public Player player;
        private Random random = new Random();

        public List<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        public Point PlayerLocation { get { return player.Location; } }
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

            player = new Player(this, playerBox, new Point(Canvas.GetLeft(playerBox), Canvas.GetTop(playerBox)));

            // Sets a position to spawn the player in the dungeon. For now it is setted up on XAML file.
            //Canvas.SetLeft(playerBox, 0);
            //Canvas.SetTop(playerBox, boundaries.Height / 2);
        }

        /// <summary>
        /// Moves the PLAYER to a specific DIRECTION and then moves the enemy in another one RANDOM.
        /// </summary>
        /// <param name="playerBox"></param>
        /// <param name="direction"></param>
        /// <param name="random"></param>
        public void Move(Rectangle playerBox, Rectangle batBox, Direction direction, Random random, Point playerLocation)
        {
            player.Move(boundaries, playerBox, direction);

            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(boundaries, playerBox, batBox, random, playerLocation);
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

        /// <summary>
        /// When an enemy hits the player, it causes a random amount of damage up to a maximum defined value.
        /// </summary>
        /// <param name="maxDamage"></param>
        /// <param name="random"></param>
        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Canvas stage, Rectangle playerBox, Rectangle batBox, Direction direction, Random random, Point playerLocation)
        {
            player.Attack(stage, playerBox, batBox, direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(stage, playerBox, batBox, random, playerLocation);
            }
        }

        public void GetRandomLocation(Rectangle character)
        {
            // Sets a character random position
            Canvas.SetLeft(character, random.Next(10, 434));
            Canvas.SetTop(character, random.Next(10, 270));
        }

        private Point GetRandomLocation(Random random, Rectangle character)
        {
            // Sets a character random position
            Canvas.SetLeft(character, random.Next(10, 434));
            Canvas.SetTop(character, random.Next(10, 270));

            return new Point(Canvas.GetLeft(character), Canvas.GetTop(character));
        }

        public void NewLevel(Rectangle batBox, Rectangle swordBox, Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>() {
                        new Bat(this, batBox, GetRandomLocation(random, batBox))
                    };
                    WeaponInRoom = new Sword(this, swordBox, GetRandomLocation(random, swordBox));
                    break;
                default:
                    break;
            }
        }
    }
}
