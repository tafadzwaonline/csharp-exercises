namespace EternalQuest;

public abstract class Goal
{
    private readonly string _name;
    private readonly string _description;
    private readonly int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    public abstract bool IsComplete { get; }

    public abstract int RecordEvent();

    public virtual string GetDetailsString()
    {
        return $"{GetStatusLabel()} {_name} ({_description})";
    }

    public abstract string GetStringRepresentation();

    protected string GetStatusLabel()
    {
        return IsComplete ? "[X]" : "[ ]";
    }
}
