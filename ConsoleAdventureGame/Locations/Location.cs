using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public abstract class Location
    {
        public Location(Player player)
        {
            Introduction();
            ConsoleUtils.ColorWriteLine("---------------", "gray");
            PerformAction(player);
        }

        protected abstract void Introduction();

        protected abstract void PerformAction(Player player);
    }
}
