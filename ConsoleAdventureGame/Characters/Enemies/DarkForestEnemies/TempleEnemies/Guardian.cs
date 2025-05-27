using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Guardian : Enemy
    {
        public override string Name { get; } = "Guardian";

        public override int Lives { get; set; } = 300;

        public override int Damage { get; } = 40;

        public override int CriticalHitChance { get; } = 2;

        public override int CriticalDamage { get; } = 70;
    }
}
