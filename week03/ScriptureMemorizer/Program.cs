using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
    
        List<Scripture> scriptures = CreateScriptureLibrary();
        Scripture scripture = scriptures[Random.Shared.Next(scriptures.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to continue or type 'quit' to finish: ");
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static List<Scripture> CreateScriptureLibrary()
    {
        return new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God.")
        };
    }
}
