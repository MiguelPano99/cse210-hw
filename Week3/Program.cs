using System;

class Program
{
    static void Main(string[] args)
    {
        // Example usage:
        Reference myReference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture myScripture = new Scripture(myReference, scriptureText);

        Console.WriteLine("Initial Scripture:");
        Console.WriteLine(myScripture.GetDisplayText());
        Console.WriteLine();

        while (!myScripture.IsCompletelyHidden())
        {
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            myScripture.HideRandomWords(3); // Hide 3 words at a time
            Console.Clear(); // Clear console for cleaner display
            Console.WriteLine(myScripture.GetDisplayText());
            Console.WriteLine();
        }

        Console.WriteLine("All words are hidden. Good job!");
    }
}