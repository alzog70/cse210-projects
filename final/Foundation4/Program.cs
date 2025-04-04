class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2025, 3, 3), 30, 3.0),
            new Cycling(new DateTime(2025, 3, 4), 45, 15.0),
            new Swimming(new DateTime(2025, 3, 5), 30, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
