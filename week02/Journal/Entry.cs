using System;

public class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string MoodRating { get; set; }

    public Entry()
    {
        Date = string.Empty;
        Prompt = string.Empty;
        Response = string.Empty;
        MoodRating = string.Empty;
    }

    public Entry(string date, string prompt, string response, string moodRating)
    {
        Date = date;
        Prompt = prompt;
        Response = response;
        MoodRating = moodRating;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Mood: {MoodRating}");
        Console.WriteLine($"Prompt: {Prompt}");
        Console.WriteLine($"{Response}");
        Console.WriteLine();
    }
}
