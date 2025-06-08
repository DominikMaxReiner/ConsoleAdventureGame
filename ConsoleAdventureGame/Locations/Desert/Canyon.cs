using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public class Canyon : Location
    {
        public Canyon(Player player) : base(player)
        {
        }

        protected override void Introduction()
        {
            string introductionText = "There is a canyon. But not just any canyon. Before you reach the one you seek, you must cross a bridge — though it doesn’t seem like a reliable crossing. The stones look weathered, the ropes frayed. It might hold, or it might not. A gamble, at best. If you’re not brave enough to risk it, there’s another way. A half mile to the north, the canyon seems to end. But beware: there are creatures lurking there, and they don’t look friendly at all. Choose wisely, for either path could lead to danger. And choose fast, it seems like a sandstorm is approaching.";

            ConsoleUtils.ColorWriteLine(introductionText, "gray");
        }

        protected override void PerformAction(Player player)
        {
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Cross the bridge", () => CrossBridge(player) },
                { "Go north", () => GoNorth(player) },
                { "Flee to the village", () => new Village(player) }
            });
        }

        private void CrossBridge(Player player)
        {
            int breakChanceValue;
            Random random = new Random();

            if (player.CurrentVehicle != null)
            {
                breakChanceValue = random.Next(1, 3); //if the the player has a vehicle, the chance of the bridge breaking is higher (50 percent)
            }
            else
            {
                breakChanceValue = random.Next(1, 5); //if the player has no vehicle, the chance of the bridge breaking is lower (25 percent)
            }

            if(breakChanceValue == 1)
            {
                ConsoleUtils.ColorWriteLine("The bridge broke and you fell into the canyon. You died.", "red");
                Respawn.RespawnPlayer(player);
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You crossed the bridge safely.", "white");
                
                EnterCanyon(player);
            }
        }

        private void GoNorth(Player player)
        {
            if(!player.PassedCanyonGuardians)
            {
                Fight.SequenceOfRandomFights(player, new List<Enemy>
                {
                    new DesertBandit(),
                    new CactusGolem()
                }, 2);
            }
            
            player.PassedCanyonGuardians = true; // set the property to true, so the player can pass the canyon guardians

            EnterCanyon(player);
        }

        private void EnterCanyon(Player player)
        {
            ConsoleUtils.ColorWriteLine("You made it to the canyon. But there is a sandstorm approaching. You should hurry.", "white");

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Go to the village", () => new Village(player) },
                { "Go into the canyon", () => WayThroughCanyon(player) }
            });
        }

        private void WayThroughCanyon(Player player)
        {
            if(player.CurrentVehicle != null)
            {
                ConsoleUtils.ColorWriteLine("You notice that the Canyon is very closely. You must leave your vehicle behind to pass.", "white");

                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Leave the vehicle behind", () => PassLabyrinth(player) },
                    { "Go to the village", () => new Village(player) }
                });
            }
            else
            {
                PassLabyrinth(player); // if the player has no vehicle, he can pass the labyrinth directly
            }

            PortalUtils.OpenPortal(player); // after passing the labyrinth, the player can open the portal to the EndFight
        }

        private void PassLabyrinth(Player player)
        {
            player.CurrentVehicle = null; // leave the vehicle behind

            ConsoleUtils.ColorWriteLine("You passed the canyon and entered... ...a labyrinth.", "white");
            ConsoleUtils.ColorWriteLine("Which way do you go?", "white");
            ConsoleUtils.ColorWriteLine("Enter your path using 'l' for left and 'r' for right, e.g.: llrrlrlrllr", "yellow");

            while(!player.PassedLabyrinth)
            {
                string playersPath = "";

                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Go back to the hut", () => new AbandonedHut(player) },
                    { "Enter the path", () => playersPath = Console.ReadLine()}
                });

                if (playersPath == player.LabyrinthPath)
                {
                    break;
                }
                else
                {
                    ConsoleUtils.ColorWriteLine("You took the wrong path.", "white");
                }
            }

            player.PassedLabyrinth = true; // set the property to true, so the player hasn`t to pass the labyrinth again
        }
    }
}
