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

        public Game(Canvas boundaries, Rectangle playerBox)
        {
            this.boundaries = boundaries;

            player = new Player(this, new Point(Canvas.GetLeft(boundaries) + 10, Canvas.GetTop(boundaries) + 70), boundaries, playerBox);
        }

        public void Move(Rectangle playerBox, Direction direction, Random random)
        {
            player.Move(playerBox, direction);
            //foreach (Enemy enemy in Enemies)
            //{
            //    enemy.Move(random);
            //}
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

        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction, random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(Canvas.GetLeft(boundaries) +
                random.Next((int)(Canvas.GetRight(boundaries) / 10 - Canvas.GetLeft(boundaries) / 10)) * 10, // X
                (int)(Canvas.GetTop(boundaries) + 
                random.Next((int)(Canvas.GetBottom(boundaries) / 10 - Canvas.GetTop(boundaries) / 10))) * 10);// Y
        }

        public void NewLevel(Random random)
        {
            level++;
            switch (level)
            {
                case 1:
                    Enemies = new List<Enemy>() {
                        new Bat(this, GetRandomLocation(random)),
                    };
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                default:
                    break;
            }
        }
    }
}
