using System.Collections.Generic;
using System;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public string Name;

        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void HelpGuide()

        {
            Console.WriteLine("");
            Console.WriteLine("Game Commands");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Go East or West - type 'go E' or 'go W'.--> This command moves your player between rooms.");
            Console.WriteLine("Use item - type 'U <item>'.-->   This command uses an item from your inventory or uses an item in the room.");
            Console.WriteLine("Take item - type 'T <item>'.-->  If an item can be picked up, this command will put the item in the player inventory.");
            Console.WriteLine("Inventory - type 'I'.-->  This command lists the current items in the player inventory.");
            Console.WriteLine("Quit game - type 'Q'.-->  This command exits the game.");
            Console.WriteLine("Help - type 'H'.-->  This command lists the Game Commands as seen here.");
            Console.WriteLine("");

        }




        // public void Quit(num){
        //       Environment.Exit(num);
        // }

        public void Setup()
        {

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Welcome to Calorie Castle!");
            Console.WriteLine("");
            // Console.WriteLine("What is your name?");
            // Console.WriteLine("");
            // string playername = Console.ReadLine();
            // Console.WriteLine("");
            // Console.WriteLine("");
            // Console.WriteLine($"<--{playername}, enjoy your time here, choose wisely, and play to win!-->");


            HelpGuide();

            Room Cake = new Room("Twinkie Room", "You find yourself in a room full of Twinkies, one of your favorites but sure to " +
            "ruin your diet! You look around the room. Boxes of Twinkies line the walls from floor to ceiling.  You are very hungry and " +
            "the sights around you are making you want to start your diet next week.  You notice a small fridge.");

            Room Cookies = new Room("Oreo Room", "You find yourself in a room full of oreos of every variety!  You are trying to watch your " +
            " eating habits but you never passed up an oreo before.  Boxes of Oreos line the walls from floor to ceiling.  You  are very hungry and " +
            "the sights are making you think about starting your diet in a day or two.  You notice a small fridge.");

            Room Candy = new Room("ButterFinger Room", "Cavities and calories all in one.  You find yourself in a room full of Butterfingers. " +
            "Boxes of butterfingers line the walls from floor to ceiling.  You are trying to stay trim but you wondering if maybe your scale " +
            "is off by 25-30 pounds.  You notice a small freezer.");

            Room Icecream = new Room("Ice-Cream Room", "A little bit of calcium and a whole lot of empty caloires. You find yourself in a freezer. " +
            "Full of cartons of Rocky Road ice-cream.  You not one to let something like this go to waste.  Though you understand that if you don't, it " +
            "will go to your waist.  You notice a freezer chest.");

            Cake.Exits.Add("E", Cookies);
            Cookies.Exits.Add("W", Cake);
            Cookies.Exits.Add("E", Candy);
            Candy.Exits.Add("W", Cookies);
            Candy.Exits.Add("E", Icecream);
            Icecream.Exits.Add("W", Candy);

            Item Twinkie = new Item("twinkie", "Golden, delicious, but you must resist eating them!");
            Item Oreo = new Item("oreo", "Plenty to go around with a fridge full of milk!");
            Item Butterfinger = new Item("butterfinger", "Sweet and salty but this is not on the healthy list!");
            Item RockyRoad = new Item("rocky road", "Don't make a rocky start on the road to wellness!");
            Item RefrigeratorVeg = new Item("fridge", "Inside you find a bag of baby carrots and sugar snap peas.");
            Item Freezer = new Item("freezer", "Inside you find partially frozen Snickers bars just how you like them.");
            Item RefrigeratorMilk = new Item("fridge", "A jug of cold and delicious milk; the perfect complement to an oreo or two.");
            Item FreezerChest = new Item("freezerchest", "You open the lid and find a medium-sized package of delicious frozen " +
            "mango. You eat some and fill your rumbling belly. ");

            Cake.Items.Add(Twinkie);
            Cake.Items.Add(RefrigeratorVeg);
            Cookies.Items.Add(Oreo);
            Cookies.Items.Add(RefrigeratorMilk);
            Candy.Items.Add(Butterfinger);
            Candy.Items.Add(Freezer);
            Icecream.Items.Add(RockyRoad);
            Icecream.Items.Add(FreezerChest);

            Player Alex = new Player("Alex", 100);

            // Alex.Inventory.Add(Oreo);

            CurrentPlayer = Alex;
            CurrentRoom = Cake;
            Look();

        }

        public void Look()
        {

            Console.WriteLine($"\nYou have entered the {CurrentRoom.Name} - {CurrentRoom.Description}\n");


            int count = 1;
            foreach (var item in CurrentRoom.Items)
            {
                Console.WriteLine($"Item {count}: {item.Name}");
                count++;
            }
            Console.WriteLine("");

            int count2 = 1;
            foreach (var item in CurrentRoom.Exits)
            {
                Console.WriteLine($"Exit {count2}: {item.Key}");
                count2++;
            }
            Console.WriteLine("");
        }

        public void Go(string direction)
        {
            CurrentRoom = CurrentRoom.Exits[direction];
            Look();

        }
        public void Reset()
        {
        }
        //No need to Pass a room since Items can only be used in the CurrentRoom
        public void UseItem(string itemName)
        {

        }

        public void TakeItem(string item)
        {
            for (var i = 0; i < CurrentRoom.Items.Count; i++)
            {


                if (CurrentRoom.Items[i].Name == item)
                {
                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                    CurrentRoom.Items.Remove(CurrentRoom.Items[i]);

                }


            }
        }
    }

}