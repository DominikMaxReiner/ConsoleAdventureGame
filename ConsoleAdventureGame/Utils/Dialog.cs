using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public static class Dialog
    {
        public static void ShowMessage(string messageSenderName, string message, string color)
        {
            ConsoleUtils.ColorWrite($"{messageSenderName}: ", "gray");
            ConsoleUtils.ColorWriteLine(message, color);
        }
    }
}
