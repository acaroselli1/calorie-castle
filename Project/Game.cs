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
            Console.WriteLine("Go East or West - type 'e' or 'w'.--> This command moves your player between rooms.");
            Console.WriteLine("Use item - type 'U <item>'.-->   This command uses an item from your inventory or an item bound to the room.");
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

            Room Cake = new Room("Twinkie Room", "You find yourself in a room full of Twinkies; one of your favorites but sure to " +
            "ruin your diet! You look around the room. Boxes of Twinkies line the walls from floor to ceiling.  You are very hungry and " +
            "the sights around you are making you want to start your diet next week.");

            Room Cookies = new Room("Oreo Room", "You find yourself in a room full of oreos of every variety!  You are trying to watch your " +
            "eating habits but you never passed up an oreo before.  Boxes of Oreos line the walls from floor to ceiling.  You  are very hungry and " +
            "the sights are making you think about starting your diet in a day or two.");

            Room Candy = new Room("ButterFinger Room", "Cavities and calories all in one.  You find yourself in a room full of Butterfingers. " +
            "Boxes of butterfingers line the walls from floor to ceiling.  You are trying to stay trim but you wondering if maybe your scale " +
            "is off by 25-30 pounds.");

            Room Icecream = new Room("Ice-Cream Room", "You find yourself in a freezer full of boxes of icecream sandwiches. A little bit of calcium and a whole lot of empty calories.  You're not one to let treats like this go to waste; though you understand that, if you don't, it will go to your waist.");
            
            Room Win = new Room("Winner's Room!!!!", "You successfully made it through all the challenges without consuming any of the foods on the unhealthy list!! Way to go to!! You are sure to make weight for the Johnny's Fitclub Challenge and win the grand prize!!!");

            Room Outside = new Room("Outside", "Well, you're back outside.  Go 'e' to play.");

            Outside.Exits.Add("e",Cake);
            Cake.Exits.Add("w",Outside);
            Cake.Exits.Add("e", Cookies);
            Cookies.Exits.Add("w", Cake);
            Cookies.Exits.Add("e", Candy);
            Candy.Exits.Add("w", Cookies);
            Candy.Exits.Add("e", Icecream);
            Icecream.Exits.Add("w", Candy);
            Icecream.Exits.Add("e", Win);
          
            Item Twinkie = new Item("twinkie box", "Golden, delicious, but you must resist eating them!");
            Item Oreo = new Item("oreo box", "Plenty to go around with a fridge full of milk!");
            Item Butterfinger = new Item("butterfinger box", "Sweet and salty but this is not on the healthy list!");
            Item IcecreamSandwich = new Item("icecream sandwich box", "Don't make a rocky start on the road to wellness!");
            Item Switch = new Item("switch", "Here's a switch with an unknown function");
            // Item RefrigeratorVeg = new Item("fridge1", "Inside you find a bag of baby carrots and sugar snap peas and satisfy your hunger with something healthy.");
            // Item Freezer = new Item("freezer", "Inside you find partially frozen Snickers bars just how you like them.");
            // Item RefrigeratorMilk = new Item("fridge2", "A jug of cold and delicious milk; the perfect complement to an oreo or two.");
            // Item FreezerChest = new Item("freezerchest", "You open the lid and find a medium-sized package of delicious frozen " +
            // "mango. You eat some and fill your rumbling belly. ");

            Cake.Items.Add(Twinkie);
            // Cake.Items.Add(RefrigeratorVeg);
            Cookies.Items.Add(Oreo);
            // Cookies.Items.Add(RefrigeratorMilk);
            Candy.Items.Add(Butterfinger);
            // Candy.Items.Add(Freezer);
            Icecream.Items.Add(IcecreamSandwich);
            Icecream.Items.Add(Switch);
            // Icecream.Items.Add(FreezerChest);

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
            Console.Clear();
            CurrentRoom = CurrentRoom.Exits[direction];
            Look();
            if (CurrentRoom.Name == "Winner's Room!!!!")
            {
               CurrentPlayer.Score = CurrentPlayer.Score + 100;
               Console.WriteLine("+100pts:  You have doubled your initial score and now have the winning total of " + CurrentPlayer.Score + " points!");
               Console.WriteLine("");
               Environment.Exit(0);


            }
        }
        public void Reset()
        {
        }
        //No need to Pass a room since Items can only be used in the CurrentRoom
        public void UseItem(string item)
        {
            if (item == "switch" && CurrentRoom.Name == "Ice-Cream Room" )
            {
            Console.WriteLine("");
            Console.WriteLine("You flip the switch not knowing its purpose.  Tired from your journey you lay down to take a short nap with freezer temperature becoming surprisingingly comfortable.  Twelve hours later you wake up dripping with sweat; feeling the affects of the summer heat wave!  You notice that the freezer once full of ice cream sandwiches is now nothing more than an ice cream pond.  The switch you flipped turned off the freezer and you're actually bathing in liquid ice cream!  The ice cream sandwich boxes are now gone from the room inventory so these are no longer an item you can take or use.");

            CurrentRoom.Items.Remove(CurrentRoom.Items[0]);

           
            }
            else
            {
            for (var i = 0; i < CurrentPlayer.Inventory.Count; i++)
                if (CurrentPlayer.Inventory[i].Name == item)
                {
                    CurrentPlayer.Score = CurrentPlayer.Score - 100;

                    if (CurrentPlayer.Score <= 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("-100pts:  You start by eating one and then eat 12.  Sorry, you're probably not going to make weight for the Johnny's Fitclub Challenge weigh-in tomorrow!  Game Over!");
                        Console.WriteLine("");
                        Environment.Exit(0);
                    }

                }
            }    
            //    for (var i = 0; i < CurrentRoom.Items.Count; i++)  
            //      if (CurrentRoom.Items[i].Name == item)
            //     {
            //         CurrentPlayer.Score = CurrentPlayer.Score +25;

            //         if (CurrentPlayer.Score == 100)
            //         {
            //             Console.WriteLine("");
            //             Console.WriteLine("Good job!  You made all the good food choices and are on your way to wellness!  You are sure to make weight for the Johnny FitClub Challenge tomorrow!  You Win!");
            //             Environment.Exit(0);
            //         }

            //     }

        }

        public void TakeItem(string item)
        {  
            for (var i = 0; i < CurrentRoom.Items.Count; i++)
            {

                if (CurrentRoom.Items[i].Name == item)
                {   
                    // Console.WriteLine(CurrentRoom.Items[i]);
                    CurrentPlayer.Inventory.Add(CurrentRoom.Items[i]);
                    CurrentRoom.Items.Remove(CurrentRoom.Items[i]);

                }


            }
        }
    }

}