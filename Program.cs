using System;
using System.Collections.Generic;
using System.IO;

namespace HelloWorld
{
    internal class Program
    {
        static string GetUserInput()
        // This method simply asks the user to input anything. No validation.
        {
            string userInput = Console.ReadLine();
            return userInput;
        }

        static double AssignValue(double comparisonValue)
        //This method will call the GetUserInput() method and validate it, verifying that it greater than the argument passed through the method.
        {
            double value;
            while (true)
            {
                // This loop will continue to ask for the user input until the user enters a valid input.
                if (double.TryParse(GetUserInput(), out value) & value > comparisonValue)
                {
                    break;
                }
                Console.WriteLine("Invalid Input");
            }
            return value;
        }

        static bool PrimeCheck(double potentialPrimeNumber)
        // This method will return true on numbers that are prime, this is done by checking all values between n - 1 and 1 and dividing n by those values.
        // Then checking if any of them return a remainder of 0, if any of them do,
        // that means that n is divisible by other numbers and therefore not a prime number.
        {
            bool isItPrime = true;
            for (double i = potentialPrimeNumber - 1; i > 1; i--)
            {
                if (potentialPrimeNumber % i == 0)
                {
                    isItPrime = false;
                    break;
                }
            }
            // This method returns true or false depending on if the number is prime or not.
            return isItPrime;
        }

        static void Main(string[] args)
        {
            // Get the user input, validate it and then assign them to variables
            Console.WriteLine("Enter a positive number: ");
            double low = AssignValue(0);

            Console.WriteLine("Enter a number larger than the previous number: ");
            double high = AssignValue(low);

            // Display the substraction of the two numbers
            Console.WriteLine($"{high} minus {low} is: {high - low}");

            // Creating a list of the numbers between the numbers the user inputted, and displaying them for largest to smallest
            List<double> ListOfNumbers = new List<double>();
            for (double i = high - 1, j = low + 1; i >= j; i--)
            {
                ListOfNumbers.Add(i);
            }

            // Writing the numbers to a numbers.txt file
            using (StreamWriter sw = new StreamWriter("C:/cprg211e/numbers.txt"))
            {
                foreach (double number in ListOfNumbers)
                {
                    sw.WriteLine(number);
                }
            }

            // Reading the numbers from the numbers.txt file, and displaying them in the console
            Console.WriteLine($"\nThe numbers between {high} and {low}, from greatest to smallest are:");
            using (StreamReader sr = new StreamReader("C:/cprg211e/numbers.txt"))
            {
                while (true)
                {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                    if (line == null)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("The prime numbers between numbers inputted are: ");
            // Using the reverse method to flip the list so it is more intuitive to read the numbers from least to greatest
            ListOfNumbers.Reverse();
            foreach (double number in ListOfNumbers)
            {
                // if the number is prime, display it to the user.
                if (PrimeCheck(number))
                {
                    Console.WriteLine(number);
                }
            }

            Console.ReadKey();
        }
    }
}