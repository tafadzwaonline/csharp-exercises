namespace Mindfulness;

public class ReflectionActivity : Activity
{
    private readonly List<string> _prompts =
    [
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    ];

    private readonly List<string> _questions =
    [
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    ];

    private readonly Queue<string> _promptRotation = new();
    private readonly Queue<string> _questionRotation = new();

    public ReflectionActivity(SessionLog sessionLog)
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            sessionLog)
    {
    }

    protected override void PerformActivity()
    {
        string prompt = GetNextShuffledItem(_prompts, _promptRotation);

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in:");
        ShowCountdown(5);
        Console.WriteLine();

        DateTime endTime = GetEndTime();
        while (DateTime.Now < endTime)
        {
            string question = GetNextShuffledItem(_questions, _questionRotation);
            int pauseSeconds = Math.Min(4, GetRemainingSeconds(endTime));

            if (pauseSeconds <= 0)
            {
                break;
            }

            Console.Write($"> {question} ");
            ShowSpinner(pauseSeconds);
            Console.WriteLine();
        }
    }
}
