using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Golem : Enemy
    {
        public override string Name { get; } = "Golem";

        public override int Lives { get; set; } = 100;

        public override int Damage { get; } = 5;

        public override int CriticalHitChance { get; } = 8;

        public override int CriticalDamage { get; } = 9;
    }
}
