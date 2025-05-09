using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAdventureGame
{
    public abstract class NonPlayerCharacter
    {
        protected abstract string Name { get; set; }

        protected NonPlayerCharacter(Player player, string name)
        {
            IntroduceYourself();
            Act(player);
            Name = name;
        }

        protected abstract void IntroduceYourself();
        protected abstract void Act(Player player);
    }
}
