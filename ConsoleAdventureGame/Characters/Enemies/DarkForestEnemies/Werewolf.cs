using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Werewolf : Enemy
    {
        public override string Name { get; } = "Werwolf";

        public override int Lives { get; set; } = 70;

        public override int Damage { get; } = 4;

        public override int CriticalHitChance { get; } = 6;

        public override int CriticalDamage { get; } = 8;
    }
}
