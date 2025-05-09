using System;

class Program
{
    static void Main(string[] args)
    {
        // Part 1: Basic guessing without loops
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }

        // Part 2: Add loop to keep guessing
        Console.Write("\nWhat is the magic number? ");
        magicNumber = int.Parse(Console.ReadLine());

        int guessCount = 0;
        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guessCount} tries!");
            }

        } while (guess != magicNumber);

        // Part 3: Random magic number
        Random random = new Random();
        magicNumber = random.Next(1, 101); // 1-100 inclusive
        guessCount = 0;

        Console.WriteLine("\nI've picked a magic number between 1-100. Try to guess it!");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            guessCount++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine($"You guessed it in {guessCount} tries!");
            }

        } while (guess != magicNumber);
    }
}