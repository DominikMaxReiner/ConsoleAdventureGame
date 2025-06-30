using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// Contains utility methods for handling fights in the game,
    /// including single and multiple enemy fights and player regeneration.
    /// </summary>
    public static class Fight
    {
        /// <summary>
        /// Starts a fight between the player and a single enemy.
        /// </summary>
        /// <param name="player">The player participating in the fight.</param>
        /// <param name="enemy">The enemy to fight against.</param>
        /// <param name="allowFlee">Indicates if the player is allowed to flee the fight.</param>
        public static void PerformFight(Player player, Enemy enemy, bool allowFlee = true)
        {
            ConsoleUtils.ColorWriteLine($"You are fighting against {enemy.Name}!", "red");
            Console.WriteLine();
            ConsoleUtils.ColorWriteLine("Do you want to fight? There is no way back...", "red");
            ConsoleUtils.ColorWriteLine("Start!", "red");

            if (allowFlee)
            {
                // Player can choose to fight or flee
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Fight", () => FightLoop(player, enemy) },
                    { "Flee to the village", () => new Village(player) }
                });
            }
            else 
            {
                // In the endgame the player has to fight, there is no way back
                FightLoop(player, enemy);
            }
        }

        // The fight loop for a single enemy fight.
        private static void FightLoop(Player player, Enemy enemy)
        {
            while (player.Lives > 0 && enemy.Lives > 0)
            {
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Attack", () => player.PerformAttack(enemy) }
                });

                if (enemy.Lives > 0)
                    enemy.PerformAttack(player);
            }
        }

        /// <summary>
        /// Continuously heals the player by regenerating lives every 8 seconds.
        /// </summary>
        /// <param name="player">The player who receives the regeneration</param>
        public static void Regeneration(Player player)
        {
            int regenerationTime = 8000; // 8 seconds
            while (true)
            {
                Thread.Sleep(regenerationTime); // wait regenerationTime milliseconds
                if (player.Lives < player.MaximumLives && player.CanRegenarateLives)
                {
                    player.Lives += 1;
                }
            }
        }

        /// <summary>
        /// Starts fights against random enemies from a provided list.
        /// </summary>
        /// <param name="player">The player participating in the fight.</param>
        /// <param name="enemies">The enemies to possibly fight against.</param>
        /// <param name="fightAmount">The amount of upcomming fights.</param>
        public static void SequenceOfRandomFights(Player player, List<Enemy> enemies, int fightAmount)
        {
            for (int i = 0; i < fightAmount; i++)
            {
                // Chooses a random enemy from the list to fight against
                Random random = new Random();
                PerformFight(player, enemies[random.Next(enemies.Count)]);

                Console.WriteLine();
                ConsoleUtils.ColorWriteLine($"-----------------", "white");
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Starts a fight with all enemies in the provided list. The player can choose which enemy to attack.
        /// </summary>
        /// <param name="player">The player participating in the fight.</param>
        /// <param name="enemies">The enemies to fight against.</param>
        /// <param name="allowFlee">Indicates if the player is allowed to flee the fight.</param>
        public static void PerformMultipleEnemyFight(Player player, List<Enemy> enemies, bool allowFlee = true)
        {
            // Presents the enemies
            ConsoleUtils.ColorWrite("You are fighting against multiple enemies! Those are ", "red");
            foreach (var enemy in enemies)
            {
                ConsoleUtils.ColorWrite($"{enemy.Name}, ", "red");
            }

            Console.WriteLine();
            ConsoleUtils.ColorWriteLine("Do you want to fight? There is no way back...", "red");
            ConsoleUtils.ColorWriteLine("Start!", "red");

            if (allowFlee)
            {
                // Player can choose to fight or flee
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Fight", () => FightLoopMultipleEnemies(player, enemies) },
                    { "Flee to the village", () => new Village(player) }
                });
            }
            else
            {
                // In the endgame the player has to fight, there is no way back
                FightLoopMultipleEnemies(player, enemies);
            }
        }

        // Handles fight loop against multiple enemies
        private static void FightLoopMultipleEnemies(Player player, List<Enemy> enemies)
        {
            while (player.Lives > 0 && enemies.Count > 0)
            {
                // Player chooses which enemy to attack
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Attack", () => SelectEnemy(player, enemies) }
                });

                for (int i = 0; i < enemies.Count; i++) //deletes an enemy with no lives left from the list
                {
                    if (enemies[i].Lives <= 0)
                    {
                        enemies.RemoveAt(i);
                    }
                }

                // Each enemy attacks the player
                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].PerformAttack(player);

                    if (player.Lives <= 0)
                        Respawn.RespawnPlayer(player);
                }
            }
        }

        // Lets the player select an enemy to attack from a list
        private static void SelectEnemy(Player player, List<Enemy> enemies)
        {
            ConsoleUtils.ColorWriteLine("Choose your opponent: ", "white");

            Dictionary<string, Action> enemySelection = new Dictionary<string, Action>();

            for (int i = 0; i < enemies.Count; i++)
            {
                int index = i;
                enemySelection.Add($"Attack {enemies[index].Name}", () => player.PerformAttack(enemies[index]));
            }

            InputUtils.GetPlayerInput(enemySelection);
        }
    }
}
