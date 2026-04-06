using Mindfulness;

// Creativity additions:
// 1. The program keeps a simple session summary that shows how many times each activity was completed.
// 2. Reflection and listing prompts rotate without repeats until all options have been used once in the session.

SessionLog sessionLog = new();
BreathingActivity breathingActivity = new(sessionLog);
ReflectionActivity reflectionActivity = new(sessionLog);
ListingActivity listingActivity = new(sessionLog);

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("Menu Options:");
    Console.WriteLine("  1. Start breathing activity");
    Console.WriteLine("  2. Start reflection activity");
    Console.WriteLine("  3. Start listing activity");
    Console.WriteLine("  4. View session summary");
    Console.WriteLine("  5. Quit");
    Console.Write("Select a choice from the menu: ");

    string choice = (Console.ReadLine() ?? string.Empty).Trim();

    switch (choice)
    {
        case "1":
            breathingActivity.Run();
            PauseBeforeMenu();
            break;
        case "2":
            reflectionActivity.Run();
            PauseBeforeMenu();
            break;
        case "3":
            listingActivity.Run();
            PauseBeforeMenu();
            break;
        case "4":
            sessionLog.DisplaySummary();
            PauseBeforeMenu();
            break;
        case "5":
            running = false;
            break;
        default:
            Console.WriteLine("Please enter a number from 1 to 5.");
            Thread.Sleep(1500);
            break;
    }
}

static void PauseBeforeMenu()
{
    Console.WriteLine();
    Console.Write("Press Enter to return to the menu.");
    Console.ReadLine();
}
