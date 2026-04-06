namespace Mindfulness;

public class ListingActivity : Activity
{
    private readonly List<string> _prompts =
    [
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    ];

    private readonly Queue<string> _promptRotation = new();

    public ListingActivity(SessionLog sessionLog)
        : base(
            "Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            sessionLog)
    {
    }

    protected override void PerformActivity()
    {
        string prompt = GetNextShuffledItem(_prompts, _promptRotation);
        List<string> items = [];

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine("Start listing items. Press Enter after each one.");

        DateTime endTime = GetEndTime();
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = (ReadResponseUntil(endTime) ?? string.Empty).Trim();

            if (!string.IsNullOrWhiteSpace(response))
            {
                items.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items!");
    }

    private string? ReadResponseUntil(DateTime endTime)
    {
        List<char> buffer = [];

        while (DateTime.Now < endTime)
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return new string(buffer.ToArray());
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (buffer.Count > 0)
                    {
                        buffer.RemoveAt(buffer.Count - 1);
                        Console.Write("\b \b");
                    }

                    continue;
                }

                if (!char.IsControl(key.KeyChar))
                {
                    buffer.Add(key.KeyChar);
                    Console.Write(key.KeyChar);
                }
            }

            Thread.Sleep(50);
        }

        if (buffer.Count > 0)
        {
            Console.WriteLine();
            return new string(buffer.ToArray());
        }

        Console.WriteLine();
        return null;
    }
}
