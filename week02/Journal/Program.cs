using System;

class Program
{
    static void Main()
    {
        
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool isRunning = true;

        while (isRunning)
        {
            DisplayMenu();
            string choice = (Console.ReadLine() ?? string.Empty).Trim();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    WriteEntry(journal, promptGenerator);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    isRunning = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine() ?? string.Empty;

        Console.Write("How would you rate your day from 1-5? ");
        string mood = Console.ReadLine() ?? string.Empty;

        Entry entry = new Entry(DateTime.Now.ToShortDateString(), prompt, response, mood);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved in memory.");
    }

    static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to: ");
        string fileName = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        journal.SaveToFile(fileName);
        Console.WriteLine("Journal saved successfully.");
    }

    static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from: ");
        string fileName = (Console.ReadLine() ?? string.Empty).Trim();

        if (string.IsNullOrWhiteSpace(fileName))
        {
            Console.WriteLine("A filename is required.");
            return;
        }

        if (journal.LoadFromFile(fileName))
        {
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("Unable to load that file.");
        }
    }
}
