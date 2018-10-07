using castle_grimtolCL;
using System;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
    public class Program
    {
        public static void Main(string[] args)
        {
            GameApi game = new GameApi();

            Console.WriteLine("");
            Console.WriteLine("Welcome to Calorie Castle!");
            Console.WriteLine("");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(game.processCommand("H"));
            game.startGame();

            
            string PlayerChoice;

            bool playing = true;

            while (playing)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("What would you like to do next? (Note: You can not use food items you have not taken.)");
                Console.ResetColor();
                PlayerChoice = Console.ReadLine();
                if (PlayerChoice == "H")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(game.processCommand(PlayerChoice));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(game.processCommand(PlayerChoice));
                }
            }


        }


        // Game loop 






    }
}

