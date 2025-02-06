using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Add a new entry");
            Console.WriteLine("2. Show all entries");
            Console.WriteLine("3. Save to file");
            Console.WriteLine("4. Load from file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (!int.TryParse(choice, out int option))
            {
                Console.WriteLine("Invalid input. Enter a number.");
                continue;
            }

            if (option == 1) journal.AddEntry();

            else if (option == 2) journal.ShowEntries();

            else if (option == 3) journal.SaveToFile();

            else if (option == 4) journal.LoadFromFile();

            else if (option == 5) break;

            else Console.WriteLine("No such option. Try again.");
        }

        Console.WriteLine("Goodbye!");
    }


class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"{Date} | {Prompt} | {Response}";
    }
}


class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private string[] prompts = 
    {
        "What was the best part of the day?",
        "What is something you learned today?",
        "Describe the funniest thing that happened.",
        "What was the hardest part of the day?",
        "What was the best food you ate today?"
    };


    public void AddEntry()
{
    Console.WriteLine("\nWould you like to use a random prompt? (yes/no)");
    string choice = Console.ReadLine().Trim().ToLower();
    
    string prompt;
    if (choice == "yes")
    {
        prompt = prompts[new Random().Next(prompts.Length)];
    }

    else
    {
        Console.Write("Enter your own prompt: ");
        prompt = Console.ReadLine();
    }

    Console.WriteLine("\n" + prompt);
    Console.Write("Your response: ");
    string response = Console.ReadLine();
    _entries.Add(new Entry(prompt, response));
    Console.WriteLine("Entry added!\n");
}



    public void ShowEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo entries yet.\n");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---\n");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }


    public void SaveToFile()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                file.WriteLine(entry);
            }
        }
        Console.WriteLine("Journal saved!\n");
    }


    public void LoadFromFile()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                _entries.Add(new Entry(parts[1].Trim(), parts[2].Trim()) { Date = parts[0].Trim() });
            }
        }
        Console.WriteLine("Journal loaded!\n");
    }
}

        
    
}