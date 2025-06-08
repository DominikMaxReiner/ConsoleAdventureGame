using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    // TODO: implement a boss bar
    public class UndeadKing : Enemy
    {
        public override string Name { get; } = "UNDEAD KING";

        public override int Lives { get; set; } = 200;

        public override int Damage { get; } = 40;

        public override int CriticalHitChance { get; } = 2;

        public override int CriticalDamage { get; } = 60;


        public override void PerformAttack(Player player)
        {
            if (Lives <= 100)
                SummonMinions();
            else
                PerformOwnAttack(player);

            RefreshBossBar();
        }

        private void SummonMinions()
        {
            // TODO: Implement the logic to summon minions
        }

        private void PerformOwnAttack(Player player)
        {
            base.PerformAttack(player);
            Random random = new Random();

            //the Undead King has a chance to heal himself when attacking
            if (random.Next(0, 2) == 2)
            {
                int regeneration = (200 - Lives) / 8;
                Lives += regeneration;
                Dialog.ShowMessage(Name, $"I have healed myself! I got {regeneration} lives.", "darkred");
            }
        }

        private void RefreshBossBar()
        {
            Console.Clear();
            ConsoleUtils.ColorWrite("BOSS BAR: ", "red");

            int maxBar = 50;

            // boss bar should only be 50 characters wide
            for (int i = 0; i < maxBar; i++)
            {
                if (i < maxBar/2 && i <= Lives)
                {
                    ConsoleUtils.ColorWrite("█", "red");
                }
                else if(i <= Lives)
                {
                    ConsoleUtils.ColorWrite("█", "green");
                }
                else
                {
                    ConsoleUtils.ColorWrite("█", "gray");
                }
            }

            Console.WriteLine();
            Console.WriteLine("-----------------------");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
