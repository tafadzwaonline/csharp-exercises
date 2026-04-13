namespace EternalQuest;

public class EternalQuestManager
{
    private readonly List<Goal> _goals = [];
    private int _score;

    public void Run()
    {
        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = ReadRequiredString("Select a choice from the menu: ");
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    CreateGoal();
                    break;
                case "4":
                    RecordEvent();
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Keep going on your eternal quest!");
                    break;
                default:
                    Console.WriteLine("Please choose a number from 1 to 7.");
                    break;
            }

            if (running)
            {
                Pause();
            }
        }
    }

    private void DisplayMenu()
    {
        TryClearConsole();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current rank: {GetRankTitle()}");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Display Player Info");
        Console.WriteLine("  2. List Goal Details");
        Console.WriteLine("  3. Create New Goal");
        Console.WriteLine("  4. Record Event");
        Console.WriteLine("  5. Save Goals");
        Console.WriteLine("  6. Load Goals");
        Console.WriteLine("  7. Quit");
        Console.WriteLine();
    }

    private void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current rank: {GetRankTitle()}");
        Console.WriteLine($"Points to next rank: {GetPointsToNextRank()}");
    }

    private void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        Console.WriteLine("The goals are:");

        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].GetDetailsString()}");
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        string choice = ReadRequiredString("Which type of goal would you like to create? ");
        string name = ReadRequiredString("What is the name of your goal? ");
        string description = ReadRequiredString("What is a short description of it? ");
        int points = ReadPositiveInt("How many points will this goal be worth each time it is recorded? ");

        Goal? goal = choice switch
        {
            "1" => new SimpleGoal(name, description, points),
            "2" => new EternalGoal(name, description, points),
            "3" => CreateChecklistGoal(name, description, points),
            _ => null
        };

        if (goal is null)
        {
            Console.WriteLine("That goal type is not available.");
            return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully.");
    }

    private ChecklistGoal CreateChecklistGoal(string name, string description, int points)
    {
        int targetCount = ReadPositiveInt("How many times does this goal need to be accomplished to complete it? ");
        int bonusPoints = ReadNonNegativeInt("How many bonus points will you earn when it is completed? ");
        return new ChecklistGoal(name, description, points, targetCount, bonusPoints);
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal before recording an event.");
            return;
        }

        Console.WriteLine("The goals are:");

        for (int index = 0; index < _goals.Count; index++)
        {
            Console.WriteLine($"{index + 1}. {_goals[index].Name}");
        }

        int selection = ReadIntInRange("Which goal did you accomplish? ", 1, _goals.Count);
        Goal selectedGoal = _goals[selection - 1];
        int pointsEarned = selectedGoal.RecordEvent();

        if (pointsEarned == 0)
        {
            Console.WriteLine("That goal has already been completed, so no additional points were awarded.");
            return;
        }

        _score += pointsEarned;
        Console.WriteLine($"Event recorded! You earned {pointsEarned} points.");
        Console.WriteLine($"You now have {_score} points.");
        Console.WriteLine($"Current rank: {GetRankTitle()}");
    }

    private void SaveGoals()
    {
        string fileName = ReadRequiredString("What is the filename for the goal file? ");

        List<string> lines =
        [
            $"Score|{_score}"
        ];

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(fileName, lines);
        Console.WriteLine("Goals saved successfully.");
    }

    private void LoadGoals()
    {
        string fileName = ReadRequiredString("What is the filename for the goal file? ");

        if (!File.Exists(fileName))
        {
            Console.WriteLine("That file could not be found.");
            return;
        }

        string[] lines = File.ReadAllLines(fileName);

        _goals.Clear();
        _score = 0;

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            string[] parts = line.Split('|');

            if (parts[0] == "Score")
            {
                _score = int.Parse(parts[1]);
                continue;
            }

            _goals.Add(CreateGoalFromData(parts));
        }

        Console.WriteLine("Goals loaded successfully.");
    }

    private static Goal CreateGoalFromData(string[] parts)
    {
        return parts[0] switch
        {
            "SimpleGoal" => new SimpleGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                bool.Parse(parts[4])),
            "EternalGoal" => new EternalGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3])),
            "ChecklistGoal" => new ChecklistGoal(
                parts[1],
                parts[2],
                int.Parse(parts[3]),
                int.Parse(parts[4]),
                int.Parse(parts[5]),
                int.Parse(parts[6])),
            _ => throw new InvalidDataException($"Unknown goal type: {parts[0]}")
        };
    }

    private string GetRankTitle()
    {
        return _score switch
        {
            >= 5000 => "Disciple Hero",
            >= 2500 => "Covenant Warrior",
            >= 1000 => "Faithful Adventurer",
            >= 250 => "Steady Seeker",
            _ => "New Pilgrim"
        };
    }

    private int GetPointsToNextRank()
    {
        int nextMilestone = _score switch
        {
            < 250 => 250,
            < 1000 => 1000,
            < 2500 => 2500,
            < 5000 => 5000,
            _ => _score
        };

        return Math.Max(0, nextMilestone - _score);
    }

    private static string ReadRequiredString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Please enter a value.");
        }
    }

    private static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number greater than 0.");
        }
    }

    private static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= 0)
            {
                return value;
            }

            Console.WriteLine("Please enter a whole number that is 0 or greater.");
        }
    }

    private static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Please enter a number from {min} to {max}.");
        }
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Press Enter to continue.");
        Console.ReadLine();
    }

    private static void TryClearConsole()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
        }
    }
}
