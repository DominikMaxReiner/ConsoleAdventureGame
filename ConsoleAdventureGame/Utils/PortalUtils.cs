using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    /// <summary>
    /// This class demonstrates two approaches for the portal animation:
    /// 1. The current sequential approach (DrawPortal), which is stable but does not allow parallel user input.
    /// 2. An alternative, commented-out approach using Thread and CancellationToken, which enables parallel animation,
    ///    but can cause issues with console input.
    /// Alternative approaches are documented in #region blocks below.
    /// </summary>
    public static class PortalUtils
    {
        public static void OpenPortal(Player player)
        {
            if (!player.CanyonKeyFound)
            {
                ConsoleUtils.ColorWriteLine("You see the portal: a key is laying on it.", "white");
                KeyManager.AddKey(player);
                player.CanyonKeyFound = true; // set the property to true, so the player can only find the key once
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You have reached the portal again.", "white");
            }

            #region Alternative: Parallel portal animation with CancellationToken (commented out)
            /*CancellationTokenSource cts = new CancellationTokenSource();
            Task.Run(() => DrawPortal(cts.Token), cts.Token);*/
            #endregion

            DrawPortal(); // start drawing the portal

            ConsoleUtils.ColorWriteLine("Do you want to activate the portal?", "white");
            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                { "Yes", () => ActivatePortal(player) },
                #region Alternative: Parallel ActivatePortal call with CancellationToken (commented out)
                //{ "Yes", () => ActivatePortal(player, cts) }, 
                #endregion
                { "Go back to the Desert", () => new Desert(player) }
            });
        }

        #region Alternative: DrawPortal method with CancellationToken for parallel animation (commented out)
        /*private static void DrawPortal(CancellationToken token)
        {
            Random random = new Random();
            int portalHeight = 50; // height of the portal
            int portalWidth = 100; // width of the portal

            while (true)
            {
                for(int i = 0; i < portalHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(new string(' ', portalWidth)); // Zeile löschen
                    Console.SetCursorPosition(0, i);

                    for (int j = 0; j < portalWidth; j++)
                    {
                        string color = "";

                        //sets the color for a possible star
                        if (random.Next(0, 2) == 0)
                        {
                            color = "magenta";
                        }
                        else
                        {
                            color = "yellow";
                        }

                        //decides if a star is drawn or not
                        if (random.Next(0, 2) == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            ConsoleUtils.ColorWrite("*", color);
                        }
                    }
                    Console.WriteLine();
                }
                //breaks if the token is cancelled
                if (token.IsCancellationRequested)
                    return;

                Thread.Sleep(50);
            }
        }*/
        #endregion

        private static void DrawPortal()
        {
            Random random = new Random();
            int portalHeight = 50; // height of the portal
            int portalWidth = 100; // width of the portal
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            // Shows the portal animation for 3 seconds
            while (stopwatch.Elapsed.TotalSeconds < 3)
            {
                for (int i = 0; i < portalHeight; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write(new string(' ', portalWidth)); // Zeile löschen
                    Console.SetCursorPosition(0, i);

                    for (int j = 0; j < portalWidth; j++)
                    {
                        string color = "";

                        //sets the color for a possible star
                        if (random.Next(0, 2) == 0)
                        {
                            color = "magenta";
                        }
                        else
                        {
                            color = "yellow";
                        }

                        //decides if a star is drawn or not
                        if (random.Next(0, 2) == 0)
                        {
                            Console.Write(" ");
                        }
                        else
                        {
                            ConsoleUtils.ColorWrite("*", color);
                        }
                    }
                    Console.WriteLine();
                }

                Thread.Sleep(50);
            }
        }

        private static void ActivatePortal(Player player) //CancellationTokenSource cts
        {
            if(player.AmountOfKeys >= 3)
            {
                ConsoleUtils.ColorWriteLine("You activated the portal. You can now enter the EndFight.", "white");
                //cts.Cancel(); // cancel the portal drawing task
                InputUtils.GetPlayerInput(new Dictionary<string, Action>
                {
                    { "Enter the portal", () => Endgame.Endfight(player) },
                    { "Go back to the Desert", () => new Desert(player) }
                });
            }
            else
            {
                OpenPortal(player);
            }
        }
    }
}
