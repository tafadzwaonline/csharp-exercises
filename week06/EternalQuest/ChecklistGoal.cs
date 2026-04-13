namespace EternalQuest;

public class ChecklistGoal : Goal
{
    private readonly int _targetCount;
    private readonly int _bonusPoints;
    private int _completedCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int completedCount = 0) : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = completedCount;
    }

    public int TargetCount => _targetCount;
    public int BonusPoints => _bonusPoints;
    public int CompletedCount => _completedCount;

    public override bool IsComplete => _completedCount >= _targetCount;

    public override int RecordEvent()
    {
        if (IsComplete)
        {
            return 0;
        }

        _completedCount++;

        if (IsComplete)
        {
            return Points + _bonusPoints;
        }

        return Points;
    }

    public override string GetDetailsString()
    {
        return $"{GetStatusLabel()} {Name} ({Description}) -- Completed {CompletedCount}/{TargetCount} times";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_targetCount}|{_bonusPoints}|{_completedCount}";
    }
}
