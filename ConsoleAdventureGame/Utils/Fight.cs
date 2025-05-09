using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Fight //TODO: implement regeneration and bow-attack
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
                if (player.Lives < 10)
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
            int enemyCount = enemies.Count;

            ConsoleUtils.ColorWrite("You are fighting against multiple enemies! Those are ", "red");
            foreach (var enemy in enemies)
            {
                ConsoleUtils.ColorWrite($"{enemy.Name}, ", "red");
            }
            ConsoleUtils.ColorWriteLine("Start!", "red");

            while (player.Lives > 0 && enemyCount > 0)
            {
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Attack", () => SelectEnemy(player, enemies) },
                    { "Flee to the village", () => new Village(player) }
                });

                for (int i = 0; i < enemyCount; i++)
                {
                    enemies[i].PerformAttack(player);
                }
            }
        }

        private static void SelectEnemy(Player player, List<Enemy> enemies)
        {
            ConsoleUtils.ColorWriteLine("Choose your opponent: ", "white");

            Dictionary<string, Action> enemySelection = new Dictionary<string, Action>();

            for (int i = 0; i < enemySelection.Count; i++)
            {
                enemySelection.Add($"Attack {enemies[i].Name}", () => player.PerformAttack(enemies[i]));
            }
        }
    }
}
