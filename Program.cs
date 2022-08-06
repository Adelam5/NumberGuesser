using System;
using System.Collections.Generic;

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
                int attempts = 10;
                List<int> guesses = new List<int>();            
                
                Console.WriteLine("Guesse a number from 1 to 100.");

                while (attempts > 0 && guess != correctNumber)
                {
                    string message = ", please try again";
                    
                    if(guesses.Count > 0)
                    {
                        guesses.Sort();
                        Console.Write("So far you have tried: ");
                        Console.WriteLine(string.Join(", ", guesses));
                    }
                    Console.WriteLine("You have {0} attempts left.", attempts);

                    string input = Console.ReadLine();

                    if(!ValidateInput(input, guess, guesses))
                    {
                        continue;
                    };

                    attempts--;

                    guess = Int32.Parse(input);

                    guesses.Add(guess);

                    if(attempts == 0)
                    {
                        message = "";
                    }

                    if (guess == correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Yellow, "You are CORRECT!!!");
                        break;
                    }

                    if (guess < correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Too low" + message);
                        continue;
                    }

                    if (guess > correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Too high" + message);
                        continue;
                    }

                }

                if (attempts == 0)
                {
                    PrintColorMessage(ConsoleColor.Red, "GAME OVER!!!");
                } else
                {
                    PrintColorMessage(ConsoleColor.Yellow, "Congratulations. You guessed it in " + (10 - attempts) + " attempts.");
                }

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
            string version = "1.1.0";
            string author = "Adela Merdžanić";

            PrintColorMessage(ConsoleColor.Green, name + ". Version: " + version + ". Author: " + author);

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

        static bool ValidateInput(string input, int guess, List<int> guesses)
        {
            if (!int.TryParse(input, out guess))
            {
                PrintColorMessage(ConsoleColor.Red, "Please enter an actual number (integer)");
                return false;
            }

            guess = Int32.Parse(input);

            if(guesses.Contains(guess))
            {
                PrintColorMessage(ConsoleColor.Red, "You already tried this number: " + guess);
                return false;
            }

            if (guess < 1 || guess > 100)
            {
                PrintColorMessage(ConsoleColor.Red, "Please enter a number from 1 to 100");
                return false;
            }

            return true;
        }
    }
}
