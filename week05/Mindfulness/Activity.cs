namespace Mindfulness;

public abstract class Activity
{
    private readonly string _name;
    private readonly string _description;
    private readonly SessionLog _sessionLog;
    private int _duration;

    protected Activity(string name, string description, SessionLog sessionLog)
    {
        _name = name;
        _description = description;
        _sessionLog = sessionLog;
    }

    public string Name => _name;

    protected int Duration => _duration;

    public void Run()
    {
        DisplayStartingMessage();
        PerformActivity();
        DisplayEndingMessage();
        _sessionLog.RecordActivity(_name, _duration);
    }

    protected abstract void PerformActivity();

    protected void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");

        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Please enter a whole number greater than 0: ");
        }

        Console.WriteLine();
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(4);
        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);
    }

    protected DateTime GetEndTime()
    {
        return DateTime.Now.AddSeconds(_duration);
    }

    protected int GetRemainingSeconds(DateTime endTime)
    {
        return Math.Max(0, (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds));
    }

    protected void ShowSpinner(int seconds)
    {
        string[] frames = ["|", "/", "-", "\\"];
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);
            Thread.Sleep(180);
            Console.Write("\b \b");
            index = (index + 1) % frames.Length;
        }

        Console.WriteLine();
    }

    protected void ShowCountdown(int seconds)
    {
        for (int remaining = seconds; remaining > 0; remaining--)
        {
            Console.Write($"{remaining} ");
            Thread.Sleep(1000);
            Console.Write("\b\b\b");
        }

        Console.Write("   \b\b\b");
        Console.WriteLine();
    }

    protected string GetNextShuffledItem(List<string> source, Queue<string> rotation)
    {
        if (rotation.Count == 0)
        {
            foreach (string item in source.OrderBy(_ => Random.Shared.Next()))
            {
                rotation.Enqueue(item);
            }
        }

        return rotation.Dequeue();
    }
}
