using System;

namespace Lab_4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int rollNumber = 1;
            int x = 0;

            Console.WriteLine("Welcome to the Grand Circus Casino!");
            Console.Write("How many sides shoud each die have? : ");
            
            
            bool validNumber = false;
            while (validNumber == false)
            {
                
                string input = Console.ReadLine();
                bool validX = Int32.TryParse(input, out x);
                if (validX == false)
                {
                    Console.Write("That is not a valid number, try again: ");
                }
                else
                {
                    validNumber = true;
                    Console.WriteLine();
                }
            }

            //Checks that the user wants to continue
            bool cont = true;
            while (cont)
            {

                int dice1 = RandomDice(x);
                int dice2 = RandomDice(x);
                int total = dice1 + dice2;


                Console.WriteLine($"Roll {rollNumber}:");
                Console.WriteLine($"You rolled a {dice1} and a {dice2} ({total} total)");
                if (x == 6)
                {
                    DiceTypes(dice1, dice2);
                    WinCraps(total);
                }
                Console.Write("Would you like to roll again? (y/n):  ");
                string resp = Console.ReadLine().ToLower();

                bool valid = false;
                while (!valid)
                {
                    if (resp != "y" && resp != "n")
                    {
                        Console.Write("That is not a correct option, enter y or n:  ");
                        resp = Console.ReadLine().ToLower();
                    }
                    else if (resp == "n")
                    {

                        Console.WriteLine("Thanks for playing!");
                        valid = true;
                        cont = false;
                    }
                    else
                    {
                        valid = true;
                        rollNumber++;
                        Console.WriteLine();
                    }


                }
            }


        }
        //Generates Random Dice taking int x from user input of how many sides
        //should the die have.
        static int RandomDice(int x)
        {
            Random rand = new Random();
            int dice = rand.Next(1, x + 1);
            return dice;
        }

        //Prints out names of dice combinations
        static void DiceTypes(int dice1, int dice2)
        {

            if (dice1 == 1 && dice2 == 1)
            {
                Console.WriteLine("Snake Eyes");
            }
            else if (dice1 == 1 && dice2 == 2)
            {
                Console.WriteLine("Ace Deuce");
            }
            else if (dice1 == 2 && dice2 == 1)
            {
                Console.WriteLine("Ace Deuce");
            }
            else if (dice1 == 6 && dice2 == 6)
            {
                Console.WriteLine("Box Cars");
            }

        }

        //Prints out win or craps based on total 
        static void WinCraps(int total)
        {
            if (total == 7 || total == 11)
            {
                Console.WriteLine("Win!");
            }
            else if (total == 2 || total == 3 || total == 12)
            {
                Console.WriteLine("Craps!");
            }

        }

    }
}