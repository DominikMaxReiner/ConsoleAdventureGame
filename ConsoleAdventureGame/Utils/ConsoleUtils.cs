using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    static class ConsoleUtils
    {
        static public void ColorWrite(string text, string color)
        {
            if(text != null)
            {
                switch (color.ToLower())
                {
                    case "black":
                        Console.ForegroundColor = ConsoleColor.Black;
                        break;
                    case "darkblue":
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        break;
                    case "darkgreen":
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        break;
                    case "darkcyan":
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        break;
                    case "darkred":
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        break;
                    case "darkmagenta":
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        break;
                    case "darkyellow":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        break;
                    case "gray":
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                    case "darkgray":
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        break;
                    case "blue":
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "cyan":
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                    case "red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "magenta":
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    case "yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "white":
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.White; // Default color (White) in case of an error
                        break;
                }

                // Output the text in the chosen color
                Console.Write(text);

                // Reset the color to default (White)
                Console.ResetColor();
            }
        }
        static public void ColorWriteLine(string text, string color)
        {
            switch (color.ToLower())
            {
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkcyan":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "darkmagenta":
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    break;
                case "darkyellow":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case "darkgray":
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White; // Default color (White) in case of an error
                    break;
            }

            // Output the text in the chosen color
            Console.WriteLine(text);

            // Reset the color to default (White)
            Console.ResetColor();
        }
    }
}
