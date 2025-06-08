using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Fight //TODO: implement bow-attack
    {
        public static void PerformFight(Player player, Enemy enemy)
        {
            ConsoleUtils.ColorWriteLine($"You are fighting against {enemy.Name}!", "red");
            Console.WriteLine();

            while (player.Lives > 0 && enemy.Lives > 0)
            {
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Attack", () => player.PerformAttack(enemy) },
                    { "Flee to the village", () => new Village(player) }
                });

                if(enemy.Lives > 0)
                    enemy.PerformAttack(player);
            }
        }

        public static void Regeneration(Player player)
        {
            while(true)
            {
                Thread.Sleep(15000); // wait 15 seconds
                if (player.Lives < player.MaximumLives)
                {
                    player.Lives += 1;
                }
            }
        }

        public static void SequenceOfRandomFights(Player player, List<Enemy> enemies, int fightAmount)
        {
            for (int i = 0; i < fightAmount; i++)
            {
                Random random = new Random();
                PerformFight(player, enemies[random.Next(enemies.Count)]);

                Console.WriteLine();
                ConsoleUtils.ColorWriteLine($"-----------------", "white");
                Console.WriteLine();
            }
        }

        public static void PerformMultipleEnemyFight(Player player, List<Enemy> enemies)
        {
            ConsoleUtils.ColorWrite("You are fighting against multiple enemies! Those are ", "red");
            foreach (var enemy in enemies)
            {
                ConsoleUtils.ColorWrite($"{enemy.Name}, ", "red");
            }
            ConsoleUtils.ColorWriteLine("Start!", "red");

            while (player.Lives > 0 && enemies.Count > 0)
            {
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Attack", () => SelectEnemy(player, enemies) },
                    { "Flee to the village", () => new Village(player) }
                });

                for (int i = 0; i < enemies.Count; i++) //deletes a dead enemy from the list
                {
                    if (enemies[i].Lives <= 0)
                    {
                        enemies.RemoveAt(i);
                    }
                }

                for (int i = 0; i < enemies.Count; i++)
                {
                    enemies[i].PerformAttack(player);

                    if (player.Lives <= 0)
                        Respawn.RespawnPlayer(player);
                }
            }
        }

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
