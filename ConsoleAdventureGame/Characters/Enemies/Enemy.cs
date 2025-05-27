using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public abstract class Enemy
    {
        public abstract string Name { get; }
        public abstract int Lives { get; set; }
        public abstract int Damage { get; }
        public abstract int CriticalHitChance { get; }
        public abstract int CriticalDamage { get; }

        public virtual void ShowLives() // TODO: check if this is still needed
        {
            if(Lives <= 0)
            {
                Lives = 0;
                ConsoleUtils.ColorWriteLine($"{Name} is defeated!", "darkred");
                Console.WriteLine();
            }
            else
            {
                Dialog.ShowMessage(Name, $"I still have {Lives} lives.", "darkred");
            }
        }

        public virtual void PerformAttack(Player player)
        {
            int damage = Attack.ReturnEnemyAttackDamage(this);
            if(player.CurrentVehicle != null)
            {
                player.CurrentVehicle.Lives -= damage;
                if (player.CurrentVehicle.Lives <= 0)
                {
                    Console.WriteLine();
                    ConsoleUtils.ColorWriteLine($"You have lost your {player.CurrentVehicle.Name}.",  "red");
                    Console.WriteLine();
                    player.CurrentVehicle = null;
                }
            }
            else
            {
                player.Lives -= damage;
            }


            if (player.Lives <= 0)
            {
                player.Lives = 0;
                Console.WriteLine();
                ConsoleUtils.ColorWriteLine($"{Name} has defeated you!", "red");
                Console.WriteLine();
                ConsoleUtils.ColorWriteLine("-----------------------", "red");
                ConsoleUtils.ColorWriteLine("-----------------------", "red");
                Console.WriteLine();
                Console.WriteLine();

                Respawn.RespawnPlayer(player);
            }
        }
    }
}
