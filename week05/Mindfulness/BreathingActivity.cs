namespace Mindfulness;

public class BreathingActivity : Activity
{
    public BreathingActivity(SessionLog sessionLog)
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.",
            sessionLog)
    {
    }

    protected override void PerformActivity()
    {
        DateTime endTime = GetEndTime();
        bool breatheIn = true;

        while (DateTime.Now < endTime)
        {
            int seconds = Math.Min(4, GetRemainingSeconds(endTime));

            if (seconds <= 0)
            {
                break;
            }

            if (breatheIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Breathe out... ");
            }

            ShowCountdown(seconds);
            Console.WriteLine();
            breatheIn = !breatheIn;
        }
    }
}
