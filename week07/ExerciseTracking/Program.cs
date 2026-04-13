using ExerciseTracking;

List<Activity> activities =
[
    new Running(new DateTime(2022, 11, 3), 30, 4.8),
    new Cycling(new DateTime(2022, 11, 3), 45, 22.0),
    new Swimming(new DateTime(2022, 11, 3), 40, 30)
];

foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}
