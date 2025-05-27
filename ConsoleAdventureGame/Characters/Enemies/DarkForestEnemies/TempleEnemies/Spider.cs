using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Spider : Enemy
    {
        public override string Name { get; } = "Spider";

        public override int Lives { get; set; } = 150;

        public override int Damage { get; } = 20;

        public override int CriticalHitChance { get; } = 5;

        public override int CriticalDamage { get; } = 30;
    }
}
