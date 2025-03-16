// I added another goal class that can track your progress. For example it tracks how many miles you have run.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

abstract class Goal
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    protected Goal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        Points = points;
        IsComplete = false;
    }

    public abstract int RecordEvent();
    public abstract string GetStatus();
}

class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => IsComplete ? "[X] " + Name : "[ ] " + Name;
}

class EternalGoal : Goal
{
    private int _currentCount;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        return Points;
    }

    public override string GetStatus() => $"[∞] {Name} (Completed {_currentCount} times)";
}

class ChecklistGoal : Goal
{
    private int _goalTarget;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int goalTarget, int bonusPoints)
        : base(name, description, points)
    {
        _goalTarget = goalTarget;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            if (_currentCount >= _goalTarget)
            {
                IsComplete = true;
                return Points + _bonusPoints;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name} (Completed {_goalTarget}/{_goalTarget})"
                          : $"[ ] {Name} (Completed {_currentCount}/{_goalTarget})";
    }
}

class GoalManager
{
    private List<Goal> _goals;
    private int _userScore;
    private string _filename = "goals.txt";

    public GoalManager()
    {
        _goals = new List<Goal>();
        _userScore = 0;
    }

    public void CreateGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _userScore += _goals[goalIndex].RecordEvent();
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
        Console.WriteLine($"Total Score: {_userScore} points\n");
    }

    public void SaveGoals()
    {
        var data = new { Goals = _goals, Score = _userScore };
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filename, json);
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        if (File.Exists(_filename))
        {
            string json = File.ReadAllText(_filename);
            var data = JsonSerializer.Deserialize<GoalManagerData>(json);
            if (data != null)
            {
                _goals = data.Goals;
                _userScore = data.Score;
                Console.WriteLine("Goals loaded successfully!");
            }
        }
    }

    private class GoalManagerData
    {
        public List<Goal> Goals { get; set; }
        public int Score { get; set; }
    }
}

class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();

        manager.CreateGoal(new SimpleGoal("Run a Marathon", "Complete a full marathon", 1000));
        manager.CreateGoal(new EternalGoal("Read Scriptures", "Read daily scriptures", 100));
        manager.CreateGoal(new ChecklistGoal("Attend Temple", "Visit the temple 10 times", 50, 10, 500));
        manager.CreateGoal(new ProgressGoal("Run 100 Miles", "Run 100 miles in total", 50, 100, 500));

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string input = Console.ReadLine();

            if (input == "1")
            {
                manager.DisplayGoals();
            }
            else if (input == "2")
            {
                Console.Write("Enter goal number to record: ");
                if (int.TryParse(Console.ReadLine(), out int goalIndex))
                {
                    manager.RecordEvent(goalIndex - 1);
                }
            }
            else if (input == "3")
            {
                manager.SaveGoals();
            }
            else if (input == "4")
            {
                manager.LoadGoals();
            }
            else if (input == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
    class ProgressGoal : Goal
{
    private int _goalTarget;
    private int _currentProgress;
    private int _bonusPoints;

    public ProgressGoal(string name, string description, int points, int goalTarget, int bonusPoints)
        : base(name, description, points)
    {
        _goalTarget = goalTarget;
        _currentProgress = 0;
        _bonusPoints = bonusPoints;
    }

    public override int RecordEvent()
    {
        if (!IsComplete)
        {
            Console.Write("Enter progress amount: ");
            if (int.TryParse(Console.ReadLine(), out int progressAmount) && progressAmount > 0)
            {
                _currentProgress += progressAmount;
                if (_currentProgress >= _goalTarget)
                {
                    IsComplete = true;
                    return Points + _bonusPoints;
                }
                return Points;  // Small reward for progress
            }
        }
        return 0;
    }

    public override string GetStatus()
    {
        return IsComplete ? $"[X] {Name} (Progress: {_goalTarget}/{_goalTarget})"
                          : $"[ ] {Name} (Progress: {_currentProgress}/{_goalTarget})";
    }
}

}