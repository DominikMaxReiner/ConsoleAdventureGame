using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class CactusGolem : Enemy
    {
        public override string Name { get; } = "Cactus Golem";

        public override int Lives { get; set; } = 80;

        public override int Damage { get; } = 10;

        public override int CriticalHitChance { get; } = 4;

        public override int CriticalDamage { get; } = 18;
    }
}
