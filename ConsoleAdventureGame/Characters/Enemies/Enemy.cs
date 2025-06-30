using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// The abstract class Enemy represents any enemy in the game.
    /// </summary>
    public abstract class Enemy
    {
        /// <summary>The name of the enemy.</summary>
        public abstract string Name { get; }
        /// <summary>The initial amount of lives of the enemy.</summary>
        public abstract int Lives { get; set; }
        /// <summary>The standard damage of the enemy.</summary>
        public abstract int Damage { get; }
        /// <summary>The probability for the enemy to make a critical hit.</summary>
        public abstract int CriticalHitChance { get; }
        /// <summary>The damage that the enemy deals on a critical hit.</summary>
        public abstract int CriticalDamage { get; }

        /// <summary>The flag that indicates if the last attack of the player will be reflected.</summary>
        public virtual bool ReflectsAttack { get; set; } = false;

        /// <summary>
        /// Shows the lives of the enemy or outputs that the enemy is dead.
        /// </summary>
        public virtual void ShowLives()
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

        /// <summary>
        /// Calculates and applies the enemy's attack damage to the player.
        /// If the player's lives drop to 0, they are defeated and respawned.
        /// </summary>
        /// <param name="player">The player that gets attacked.</param>
        public virtual void PerformAttack(Player player)
        {
            int damage = Attack.ReturnEnemyAttackDamage(this);

            DealDamage(damage, player);

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

        /// <summary>
        /// Subtracts the dealt damage from the player's lives; or vehicle lives if the player owns a vehicle.
        /// </summary>
        /// <param name="damage">The dealt damage.</param>
        /// <param name="player">The player that gets attacked.</param>
        public virtual void DealDamage(int damage, Player player)
        {
            if (player.CurrentVehicle != null)
            {
                player.CurrentVehicle.Lives -= damage;
                if (player.CurrentVehicle.Lives <= 0)
                {
                    Console.WriteLine();
                    ConsoleUtils.ColorWriteLine($"You have lost your {player.CurrentVehicle.Name}.", "red");
                    Console.WriteLine();
                    player.CurrentVehicle = null;
                }
            }
            else
            {
                player.Lives -= damage;
            }
        }
    }
}
