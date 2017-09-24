using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            Console.ResetColor();
            Project.Game Game = new Project.Game();
            Game.Setup();

            string PlayerChoice;

            bool playing = true;

            while (playing)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What would you like to do next? (Note: You can not use food items you have not taken.)");
                Console.ResetColor();
                PlayerChoice = Console.ReadLine();
                validateChoice(PlayerChoice);
            }


            void validateChoice(string playerchoice)
            {

                if (playerchoice == "e" || playerchoice == "w" || playerchoice == "U" || playerchoice == "T twinkie box" || playerchoice == "T oreo box" || playerchoice == "T icecream sandwich box" || playerchoice == "T butterfinger box" || playerchoice == "I" || playerchoice == "Q" || playerchoice == "H" || playerchoice == "U twinkie box" || playerchoice == "U oreo box" || playerchoice == "U butterfinger box" || playerchoice == "U icecream sandwich box"|| playerchoice == "U switch")
                {

                    Play(playerchoice);

                }
                else
                {
                    Console.WriteLine("");
                    System.Console.WriteLine("Please use a command from the Game Commands.  Type 'H' for the list of Game Commands.");
                    PlayerChoice = Console.ReadLine();
                    validateChoice(PlayerChoice);
                }

            }

            void ListPlayerInventory()
            {
                if (Game.CurrentPlayer.Inventory.Count == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Nothing in inventory");

                }
                else
                {
                    foreach (var item in Game.CurrentPlayer.Inventory)
                    {
                        Console.WriteLine("");
                        Console.WriteLine($"Item in Inventory: {item.Name}");
                        Console.WriteLine("");
                    }
                }
            }


            void Play(string playerchoice)
            {

                switch (playerchoice)
                {
                    case "I":
                        ListPlayerInventory();
                        break;
                    case "H":
                        Game.HelpGuide();
                        break;
                    case "Q":
                        Environment.Exit(0);
                        break;
                    case "T twinkie box":
                        Game.TakeItem("twinkie box");
                        break;
                    case "T oreo box":
                        Game.TakeItem("oreo box");
                        break;
                    case "T butterfinger box":
                        Game.TakeItem("butterfinger box");
                        break;
                    case "T icecream sandwich box":
                        Game.TakeItem("icecream sandwich box");
                        break;
                   case "U twinkie box":
                        Game.UseItem("twinkie box");
                        break;
                    case "U oreo box":
                        Game.UseItem("oreo box");
                        break;
                    case "U butterfinger box":
                        Game.UseItem("butterfinger box");
                        break;
                    case "U icecream sandwich box":
                        Game.UseItem("icecream sandwich box");
                        break; 
                    case "U switch":
                        Game.UseItem("switch");
                        break;    
                    // case "U fridge1":
                    //     Game.UseItem("fridge1");
                    //     break;
                    // case "U fridge2":
                    //     Game.UseItem("fridge2");
                    //     break;
                    // case "U freezerchest":
                    //     Game.UseItem("freezerchest");
                    //     break;
                    // case "U freezer":
                    //     Game.UseItem("freezer");
                    //     break;
                    case "e":
                        Game.Go("e");
                        break;
                    case "w":
                        Game.Go("w");
                        break;

                }
            }



        }


        // Game loop 






    }
}

