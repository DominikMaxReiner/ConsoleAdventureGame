using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Zombie : Enemy
    {
        public override string Name { get; } = "Zombie";

        public override int Lives { get; set; } = 50;

        public override int Damage { get; } = 2;

        public override int CriticalHitChance { get; } = 5;

        public override int CriticalDamage { get; } = 4;
    }
}
