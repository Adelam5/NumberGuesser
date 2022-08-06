using System;

namespace NumberGuesser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            GreetUser();

         
            while (true)
            {
                Random random = new Random();

                int correctNumber = random.Next(1, 100);
                int guess = 0;

                Console.WriteLine("Guesse a number from 1 to 100");

                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Please enter an actual number");
                        continue;
                    }

                    guess = Int32.Parse(input);

                    if (guess < correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Too low, please try again");
                    }

                    if (guess > correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Too high, please try again");
                    }
                }

                PrintColorMessage(ConsoleColor.Yellow, "You are CORRECT!!!");

                Console.WriteLine("Play again? [Y or N]");
                string answer = Console.ReadLine().ToUpper();

                if(answer == "Y")
                {
                    continue;
                } else
                {
                    return;
                }
            }
        }

        static void GetAppInfo ()
        {
            string name = "Number Guesser";
            string version = "1.0.0";
            string author = "Adela Merdžanić";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}. Version: {1}. Author: {2}", name, version, author);
            Console.ResetColor();
        }

        static void GreetUser()
        {
            Console.WriteLine("What is your name?");

            string player = Console.ReadLine();
            Console.WriteLine("Hello {0}, lets play a game", player);
        }

        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
