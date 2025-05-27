using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class DesertBandit : Enemy
    {
        public override string Name { get; } = "Desert Bandit";

        public override int Lives { get; set; } = 60;

        public override int Damage { get; } = 5;

        public override int CriticalHitChance { get; } = 2;

        public override int CriticalDamage { get; } = 10;

        public int StealAmount { get; } = 70;


        public override void PerformAttack(Player player)
        {
            player.Coins -= StealAmount;
            Dialog.ShowMessage(Name, $"I stole {StealAmount} coins from you!", "darkred");
            Console.WriteLine();

            base.PerformAttack(player);
        }
    }
}
