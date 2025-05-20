using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string EntryText { get; set; }

    public Entry(string date, string promptText, string entryText)
    {
        Date = date;
        PromptText = promptText;
        EntryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date}");
        Console.WriteLine($"Prompt: {PromptText}");
        Console.WriteLine($"Entry: {EntryText}");
        Console.WriteLine();
    }
}

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries:");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_entries.Count);
                
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.PromptText}|{entry.EntryText}");
                }
            }
            Console.WriteLine($"Journal saved to file: {filename}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error saving journal to file: {e.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("The file does not exist. A new journal will be created.");
                return;
            }

            _entries.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                int entryCount = int.Parse(reader.ReadLine());

                for (int i = 0; i < entryCount; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    
                    if (parts.Length == 3)
                    {
                        string date = parts[0];
                        string promptText = parts[1];
                        string entryText = parts[2];
                        _entries.Add(new Entry(date, promptText, entryText));
                    }
                    else
                    {
                        Console.WriteLine($"Error reading entry {i + 1} from file. The entry will be skipped.");
                    }
                }
            }
            Console.WriteLine($"Journal loaded from file: {filename}");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Error loading journal from file: {e.Message}");
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Error reading the number of entries or the date format: {e.Message}. A new journal will be created.");
            _entries.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred: {e.Message}. A new journal will be created.");
            _entries.Clear();
        }
    }
}

public class PromptGenerator
{
    private List<string> _prompts = new List<string>
    {
        "What was the best moment of your day?",
        "What made you smile today?",
        "What did you learn today?",
        "What are you grateful for today?",
        "Describe a positive interaction you had today.",
        "What could you have done better today?",
        "How did you feel today?",
        "What inspired you today?",
        "If you could relive one moment from today, what would it be?",
        "What would you like to remember about today in the future?"
    };

    public string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
        {
            return "No prompts available.";
        }
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        string filename = "journal.txt";

        journal.LoadFromFile(filename);

        while (true)
        {
            Console.WriteLine("\nPersonal Journal");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string date = DateTime.Now.ToShortDateString();
                    string promptText = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"Date: {date}");
                    Console.WriteLine($"Prompt: {promptText}");
                    Console.Write("Your entry: ");
                    string entryText = Console.ReadLine();
                    journal.AddEntry(new Entry(date, promptText, entryText));
                    Console.WriteLine("Entry added to journal.");
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    filename = Console.ReadLine();
                    journal.SaveToFile(filename);
                    break;
                case "4":
                    Console.Write("Enter the filename to load the journal from: ");
                    filename = Console.ReadLine();
                    journal.LoadFromFile(filename);
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the Personal Journal. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
