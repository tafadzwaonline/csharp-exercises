namespace Mindfulness;

public class SessionLog
{
    private readonly Dictionary<string, int> _activityCounts = new();
    private readonly Dictionary<string, int> _activitySeconds = new();

    public void RecordActivity(string activityName, int duration)
    {
        if (!_activityCounts.ContainsKey(activityName))
        {
            _activityCounts[activityName] = 0;
            _activitySeconds[activityName] = 0;
        }

        _activityCounts[activityName]++;
        _activitySeconds[activityName] += duration;
    }

    public void DisplaySummary()
    {
        Console.Clear();
        Console.WriteLine("Session Summary");
        Console.WriteLine();

        if (_activityCounts.Count == 0)
        {
            Console.WriteLine("No activities completed yet.");
            return;
        }

        foreach (string activityName in _activityCounts.Keys.OrderBy(name => name))
        {
            Console.WriteLine($"{activityName}: {_activityCounts[activityName]} time(s), {_activitySeconds[activityName]} total second(s)");
        }
    }
}
