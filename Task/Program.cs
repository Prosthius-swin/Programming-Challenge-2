using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumDiceRolls;
            double diceRollsAverage;
            int diceRollsTotal;

            string menuSelection = "";
            string menu = "1. Roll dice \n2. Calculate average, total, or list all previous rolls \n3. Write rolls to file \n4. Load rolls and show amount of rolls, total and average \n5. Exit \n\n";
            string lineSeparator = "-------------------------";
            List<int> diceRolls = new List<int>();

            while(menuSelection != "5")
            {
                int counter = 0;
                string rollAgain = "y";
                string numberDiceRolls = "0";

                Console.Write(menu);
                menuSelection = Console.ReadLine();
                Console.WriteLine(lineSeparator + "\n");
                switch(menuSelection)
                {
                    //Roll dice
                    case "1":
                        while (rollAgain == "y" && Int32.Parse(numberDiceRolls) <= 50 && Int32.Parse(numberDiceRolls) >= 0) 
                        {
                            Console.WriteLine("How many dice do you want to roll?");
                            numberDiceRolls = Console.ReadLine();
                            Console.WriteLine();
                            if (Int32.Parse(numberDiceRolls) > 50) 
                            {
                                Console.WriteLine();
                                Console.WriteLine("Maximum number of rolls is 50. Please choose again.");
                                numberDiceRolls = Console.ReadLine();
                            } else if (Int32.Parse(numberDiceRolls) < 0) 
                            {
                                Console.WriteLine();
                                Console.WriteLine("Please input a positive number.");
                                numberDiceRolls = Console.ReadLine();
                            }
                            while (counter < (Int32.Parse(numberDiceRolls))) 
                            {
                                Random rnd = new Random();
                                diceRolls.Add(rnd.Next(1, 7));
                                counter++;   
                            }
                            foreach(int i in diceRolls)
                            {
                                Console.WriteLine(i);
                            }
                            Console.WriteLine();
                            Console.WriteLine("Delete previous rolls and roll again? (y/n)");
                            rollAgain = Console.ReadLine().ToLower();
                            if(rollAgain == "y")
                            {
                                counter = 0;
                            } else
                            {
                                Console.WriteLine("\nSaving rolls");
                            }
                            Console.WriteLine(lineSeparator + "\n");   
                        }

                    break;

                    //Calculate average, total, list the rolls
                    case "2":
                        string caseTwoChoice = "";

                        while(caseTwoChoice != "D")
                        {
                            Console.WriteLine("A. Calculate average of rolls \nB. Calculate sum of rolls \nC. List all rolls \nD. Return to main menu \n");
                            caseTwoChoice = Console.ReadLine().ToUpper();
                            switch(caseTwoChoice)
                            {
                                //Calculate average of rolls
                                case "A":
                                    diceRollsAverage = diceRolls.Average();
                                    Console.WriteLine($"\nThe average of all rolls is {diceRollsAverage}\n {lineSeparator}\n");
                                break;

                                //Calculate sum of rolls
                                case "B":
                                    sumDiceRolls = diceRolls.Sum();
                                    Console.WriteLine($"\nThe sum of all rolls is {sumDiceRolls}\n {lineSeparator}\n");
                                break;

                                //List all rolls
                                case "C":
                                Console.WriteLine();
                                    foreach(int i in diceRolls)
                                    {
                                        Console.Write($"{i} ");
                                    }
                                    Console.WriteLine($"\n{lineSeparator}\n");
                                break;

                                //Return to main menu
                                case "D":
                                    Console.WriteLine($"\nReturning to main menu\n{lineSeparator}\n");
                                break;
                            }
                        }
                    break;

                    //Write the rolls to file, do not overwrite rolls already saved
                    case "3":
                       using (StreamWriter writer = File.AppendText("./SavedDiceRolls/SavedDiceRolls.csv"))
                        {
                            foreach(int i in diceRolls)
                            {
                                writer.WriteLine(i);
                            }
                            Console.WriteLine($"Dice rolls saved successfully\n{lineSeparator}\n");
                        } 
                    break;

                    //Read rolls from text file, display amount of rolls, total, average
                    case "4":
                        string[] savedDiceRollsStr = File.ReadAllLines("./SavedDiceRolls/SavedDiceRolls.csv");
                        int[] savedDiceRollsInt = Array.ConvertAll(savedDiceRollsStr, s => int.Parse(s));
                        foreach(char i in savedDiceRollsInt)
                        {
                            diceRolls.Add((int)i);
                        }
                        diceRollsTotal = diceRolls.Count();
                        Console.WriteLine($"The total number of rolls is {diceRollsTotal}.");

                        sumDiceRolls = diceRolls.Sum();
                        Console.WriteLine($"\nThe sum of all rolls is {sumDiceRolls}.");

                        diceRollsAverage = diceRolls.Average();
                        Console.WriteLine($"\nThe average of all rolls is {diceRollsAverage}.\n {lineSeparator}\n");
                    break;

                    //Exit
                    case "5":
                    Console.WriteLine("Exiting program");
                    break;
                }
            }       
        }
    }
}
