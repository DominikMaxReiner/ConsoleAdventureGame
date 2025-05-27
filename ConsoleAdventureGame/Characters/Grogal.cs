using ConsoleAdventureGame.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    class Grogal
    {
        public Grogal(string playerName)
        {
            Console.WriteLine();
            string introduction = $"Hello {playerName}, my name is Grogal. I am your friend and helper here in the village. In general, it is important to know that you must face 3 challenges, where you will receive a key as a result (or die...). With these 3 keys, you can activate the portal in the desert to complete the game. The entire village is available to help you, including a weaponsmith and a vehicle dealer. There is also a gas station right here ;). Take these 100 coins to get started and find your way around. By the way, I heard that the vehicle dealer has a job opening, so if you want more coins, you can give it a try. If you're interested in current game data, you can enter //l for your lives, //k for the number of keys you've collected, and //m for the number of coins you have. Here's your first key from me:";


            Dialog.ShowMessage("Grogal", introduction, "green");

            Player player = new Player(playerName);

            //start the thread of regeneration
            Task.Run(() => Fight.Regeneration(player));

            player.AmountOfKeys += 1;
            InputUtils.CurrentPlayer = player;
            Console.WriteLine("----------------");

            Village village = new Village(player);
        }
    }
}
