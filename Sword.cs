using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace The_Mission
{
    class Sword : Weapon
    {
        public Sword(Game game)
            :base(game) { }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random)
        {
            // Your code goes here
        }
    }
}
