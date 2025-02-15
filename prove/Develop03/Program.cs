using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Program!");

        List<Scripture> scriptures = LoadScriptures("scriptures.txt");

        if (scriptures.Count == 0)
        {
            scriptures = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that He gave His only begotten Son, that whoever believes in Him should not perish but have everlasting life."),

                new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.")

            };
        }
        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];
        
        while (true)
        {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine("\nPress Enter to hid words, type 'add' to add a new scripture, or quit to exit.");
            string input = Console.ReadLine()?.ToLower();

            if (input == "quit") break;
            if (input == "add")
            {
                AddNewScripture(scriptures, "scriptures.txt");
                continue;
            }

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.DisplayScripture();
                Console.WriteLine("\nAll words are hidden. Press enter to exit.");
                Console.ReadLine();
                break;
            }
        }
    }
    static List<Scripture> LoadScriptures(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (File.Exists(filename))
        {
            foreach (var line in File.ReadLines(filename))
            {
                var parts = line.Split('|');
                if (parts.Length < 2) continue;

                Reference reference = ParseReference(parts[0]);
                scriptures.Add(new Scripture(reference, parts[1]));
            }
        }
        return scriptures; 
    }



    static void AddNewScripture(List<Scripture> scriptures, string filename)
    {
        Console.Write("Enter the book name: ");
        string book = Console.ReadLine();

        Console.Write("Enter the chapter number: ");
        int chapter = int.Parse(Console.ReadLine());

        Console.Write("Enter the starting verse number: ");
        int startVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter the ending verse number (or the same as the start if single verse): ");
        int endVerse = int.Parse(Console.ReadLine());

        Console.Write("Enter the scripture text: ");
        string text = Console.ReadLine();

        Scripture newScripture = new Scripture(new Reference(book, chapter, startVerse, endVerse), text);
        scriptures.Add(newScripture);

       
        File.AppendAllText(filename, $"{book} {chapter}:{startVerse}-{endVerse}|{text}\n");

        Console.WriteLine("Scripture added successfully! Press Enter to continue.");
        Console.ReadLine();
    }


    static Reference ParseReference(string reference)
    {
        string[] parts = reference.Split(' ');
        string book = parts[0];
        string[] chapterVerse = parts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);
        string[] verses = chapterVerse[1].Split('-');
        int startVerse = int.Parse(verses[0]);
        int endVerse = verses.Length > 1 ? int.Parse(verses[1]) : startVerse;

        return new Reference(book, chapter, startVerse, endVerse);
    }
}


class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int endVerse = -1)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse == -1 ? startVerse : endVerse;
    }


    public override string ToString()
    {
        return EndVerse == StartVerse ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void HideWord()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        return IsHidden ? "_____" : Text;
    }
}


class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }


    public void DisplayScripture()
    {
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words));
    }


    public void HideRandomWords()
    {
        int attempts = 0;
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();

        while (attempts < 3 && visibleWords.Count > 0)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].HideWord();
            visibleWords.RemoveAt(index);
            attempts++;
        }
    }



    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}

