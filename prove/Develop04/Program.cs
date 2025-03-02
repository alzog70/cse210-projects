using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected string Name;
    protected string Description;
    protected int Duration;

    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public void Start()
    {
        Console.WriteLine($"\nStarting {Name}...");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Animate(3);
        Run();
        End();
    }

    protected void Animate(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(". ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    protected abstract void Run();

    private void End()
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Animate(3);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Exercise", "This activity will help you relax by guiding you through breathing in and out slowly.") {}

    protected override void Run()
    {
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Breathe in...");
            Animate(3);
            Console.WriteLine("Breathe out...");
            Animate(3);
            elapsed += 6;
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private static readonly string[] Questions =
    {
        "Why was this experience meaningful to you?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What did you learn about yourself?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you think about moments when you've shown strength and resilience.") {}

    protected override void Run()
    {
        Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine(Questions[new Random().Next(Questions.Length)]);
            Animate(5);
            elapsed += 5;
        }
    }
}

class ListingActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Exercise", "This activity helps you focus on positive things by listing as many as you can in a given area.") {}

    protected override void Run()
    {
        Console.WriteLine(Prompts[new Random().Next(Prompts.Length)]);
        Animate(3);
        Console.WriteLine("Start listing now!");
        int count = 0;
        DateTime startTime = DateTime.Now;
        while ((DateTime.Now - startTime).TotalSeconds < Duration)
        {
            Console.ReadLine();
            count++;
        }
        Console.WriteLine($"You listed {count} items!");
    }
}

class VisualizationActivity : Activity
{
    private static readonly string[] Visualizations =
    {
        "Imagine you are sitting on a quiet beach, feeling the warmth of the sun.",
        "Picture yourself in a peaceful forest, listening to the sound of birds.",
        "Visualize a moment of success and joy in your life.",
        "Imagine you are floating on a cloud, feeling completely weightless."
    };

    public VisualizationActivity() : base("Visualization Exercise", "This activity helps you relax by guiding you through peaceful mental imagery.") {}

    protected override void Run()
    {
        Console.WriteLine(Visualizations[new Random().Next(Visualizations.Length)]);
        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.WriteLine("Focus on the details of this scene...");
            Animate(5);
            elapsed += 5;
        }
    }
}

class Program
{
    static void Main()
    {
        Dictionary<string, Activity> activities = new Dictionary<string, Activity>
        {
            { "1", new BreathingActivity() },
            { "2", new ReflectionActivity() },
            { "3", new ListingActivity() },
            { "4", new VisualizationActivity() }
        };

        while (true)
        {
            Console.WriteLine("\nChoose an activity:");
            Console.WriteLine("1. Breathing Exercise");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing Exercise");
            Console.WriteLine("4. Visualization Exercise");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            if (activities.ContainsKey(choice))
            {
                activities[choice].Start();
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}
