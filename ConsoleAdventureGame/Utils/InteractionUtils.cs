using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class InteractionUtils
    {
        static public void BuySomething<T>(Player player, int price, T value, ref T property)
        {
            if (player.Coins >= price)
            {
                player.Coins -= price;
                property = value;
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have enough coins.", "gray");
            }
        }
        static public void BuySomething(Player player, int price, int amount, ref int property)
        {
            if (player.Coins >= price * amount)
            {
                player.Coins -= price * amount;
                property += amount;
            }
            else
            {
                ConsoleUtils.ColorWriteLine("You don't have enough coins.", "gray");
            }
        }
        static public int PerformTransaction(Player player, bool isTransactionSuccess, string successMessage, string errorMessage)
        {
            int intermediateVariable = 0;

            if (isTransactionSuccess)
            {
                ConsoleUtils.ColorWriteLine(successMessage, "cyan");

                int price = 1;
                int amount = InputUtils.GetPlayerInputNumber();

                BuySomething(player, price, amount, ref intermediateVariable);
            }
            else
            {
                ConsoleUtils.ColorWriteLine(errorMessage, "red");
            }
            Console.WriteLine("--------------------");
            Console.WriteLine();

            return intermediateVariable;
        }
    }
}
