using System;
using System.Collections.Generic;
using System.IO;

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
            Console.WriteLine("Journal saved to file: " + filename);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error saving journal to file: " + e.Message);
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("The file does not exist.  A new journal will be created.");
                return;
            }

            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                int count = int.Parse(reader.ReadLine());
                for (int i = 0; i < count; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        _entries.Add(new Entry(parts[0], parts[1], parts[2]));
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid entry at line {i + 1}");
                    }
                }
            }
            Console.WriteLine("Journal loaded from file: " + filename);
        }
        catch (IOException e)
        {
            Console.WriteLine("Error loading journal from file: " + e.Message);
        }
        catch (FormatException e)
        {
            Console.WriteLine($"Error reading file format. A new journal will be created. Error Details: {e.Message}");
            _entries.Clear();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred. A new journal will be created. Error Details: {e.Message}");
            _entries.Clear();
        }
    }
}
