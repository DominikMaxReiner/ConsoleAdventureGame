using ConsoleAdventureGame.Utils;
using System.Web;

namespace ConsoleAdventureGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleUtils.ColorWrite("Enter your name: ", "gray");

            Grogal grogal = new Grogal(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
