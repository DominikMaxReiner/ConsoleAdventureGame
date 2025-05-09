using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleAdventureGame
{
    public class Customer
    {
        protected string Name { get; set; }
        private Vehicle WantedVehicle;

        public Customer(Player player)
        {
            WantedVehicle = ReturnVehicle();
            Name = ReturnName();
            IntroduceYourself();
            Act(player);
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine();
        }

        private static string ReturnName()
        {
            string[] names = {"Adrian", "Alicia", "Amelie", "Anna", "Antonia", "Arthur", "Benjamin", "Bianca", "Carla", "Charlotte",
                                "Chloe", "Clara", "David", "Dennis", "Diana", "Elena", "Emma", "Erik", "Felix", "Frederik", "Franziska",
                                "Freya", "Gisela", "Giulia", "Gustav", "Hannah", "Henry", "Isabel", "Isabella", "Jana", "Jannik", "Johanna",
                                "Jonah", "Jonas", "Josephine", "Julia", "Justus", "Katharina", "Kerstin", "Klara", "Leo", "Leonard", "Lena",
                                "Ludwig", "Luis", "Luca", "Lukas", "Maja", "Marlene", "Matthias", "Michael", "Mia", "Moritz", "Mira", "Monika",
                                "Nina", "Noah", "Oskar", "Paula", "Paul", "Paulina", "Philipp", "Robin", "Robert", "Sabrina", "Samuel", "Sarah",
                                "Selina", "Sophia", "Stefan", "Sophie", "Stella", "Tanja", "Theodor", "Tim", "Tobias", "Tom", "Tommy", "Valentina",
                                "Vera", "Victoria", "Walter", "Zoe"};

            //Randomize the name selection
            Random random = new Random();
            int index = random.Next(names.Length);

            return names[index];
        }

        private static Vehicle ReturnVehicle()
        {
            Vehicle[] vehicles = { new Car(), new Airplane(), new Tank() };
            //Randomize the vehicle selection
            Random random = new Random();
            int index = random.Next(vehicles.Length);
            return vehicles[index];
        }

        protected void Act(Player player)
        {
            Dialog.ShowMessage(Name, $"Here are {WantedVehicle.Price} coins. Does that work for you?", "blue");

            InputUtils.GetPlayerInput(new Dictionary<string, Action>
            {
                {"Yes, sure" , () => SellWithPercent(player, 0)},
                {"No, that's too few coins. I want 10% more." , () => SellWithPercent(player, 10)},
                {"No, that's too few coins. I want 20% more." , () => SellWithPercent(player, 20)},
                {"No, that's too few coins. I want 30% more." , () => SellWithPercent(player, 30)},
                {"No, that's too few coins. I want 40% more." , () => SellWithPercent(player, 40)},
                {"No, that's too few coins. I want 50% more." , () => SellWithPercent(player, 50)},
                {"I want to quit" , () => new VehicleStore(player)}
            });
        }

        private void SellWithPercent(Player player, int percent)
        {
            Random random = new Random();
            
            if (random.Next(0, percent) < 10)
            {
                Dialog.ShowMessage(Name, $"Of course! Here are the coins:", "blue");
                SellCar(player, WantedVehicle.Price + (WantedVehicle.Price * (percent / 100)));
            }
            else
            {
                Dialog.ShowMessage(Name, "I can't give you any more coins.", "blue");
            }
        }

        private void SellCar(Player player, int price)
        {
            Dialog.ShowMessage(player.Name, $"Here is the key to your new {WantedVehicle.Name}.", "white");
            
            player.Coins += price/3;
        }

        protected void IntroduceYourself()
        {
            string introductionText = $"Hello, I am {Name}. I am here to buy a {WantedVehicle.Name}.";
            Dialog.ShowMessage(Name, introductionText, "blue");
        }
    }
}
