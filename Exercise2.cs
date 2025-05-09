using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirements
        Console.Write("Enter your grade percentage: ");
        int gradePercentage = int.Parse(Console.ReadLine());

        string letter = "";
        string sign = "";

        // Determine letter grade
        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine +/-
        if (letter != "F") // No + or - for F grades
        {
            int lastDigit = gradePercentage % 10;
            
            if (gradePercentage >= 93) // Handle A+ exception
            {
                sign = "-";
            }
            else if (lastDigit >= 7 && letter != "A") // No A+
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Print final grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine pass/fail message
        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Keep working hard for next time!");
        }
    }
}