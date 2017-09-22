using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Project.Game Game = new Project.Game();
            Game.Setup();
            
            string PlayerChoice;

            bool playing = true;
            
            while(playing)
            {
            Console.WriteLine("");    
            Console.WriteLine("What would you like to do next?");
            PlayerChoice = Console.ReadLine();
            validateChoice(PlayerChoice);
            }


            void validateChoice(string playerchoice)
            {

                if (playerchoice == "go E" || playerchoice == "go W" || playerchoice == "U" || playerchoice == "T twinkie" || playerchoice == "T oreo" || playerchoice == "T rocky road" || playerchoice == "T butterfinger" || playerchoice == "I" || playerchoice == "Q" || playerchoice == "H")
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
                    case "Q": Environment.Exit(0);
                        break;
             case "T twinkie": Game.TakeItem("twinkie");
                        break;
             case "T oreo": Game.TakeItem("oreo");
                        break;
        case "T butterfinger": Game.TakeItem("butterfinger");
                        break;
        case "T rocky road": Game.TakeItem("rocky road");
                        break;
                    // case "U": y;
                    //     break;
                 case "go E": Game.Go("E");
                        break;
                 case "go W": Game.Go("W");
                       break;
                    
                }
            }



        }


        // Game loop 






    }
}

