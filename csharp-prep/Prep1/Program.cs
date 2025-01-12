using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What Grade did you get?");
        string grade = Console.ReadLine();
        int number = int.Parse(grade);

        string letter = "";

        if (number >= 90)
            {
                letter = "A";
                // Console.Write("You got an A.");
                // Console.Write("You passed the class!");
            }
        else if (number >= 80)
            {
                letter = "B";
                // Console.Write("You got a B.");
                // Console.Write("You passed the class!");
            }
        else if (number >= 70)
            {
                letter = "C";
                // Console.Write("You got a C.");
                // Console.Write("You passed the class!");
            }
        else if (number >= 60)
            {
                letter = "D";
                // Console.Write("You got a D.");
                // Console.Write("You didn't pass the class. You can do it next time!");
            }
        else 
            {
                letter = "F";
                // Console.Write("You got an F.");
                // Console.Write("You didn't pass the class. You can do it next time!");
            }

        Console.WriteLine($"Your grade is {letter}");

        if (number >= 70)
            {
                Console.WriteLine("You passed the class.");
            }
        else 
            {
                Console.Write("You didn't pass the class. You can do it next time!");
            }

            // Other Program #1
        // Console.Write("What is your first name?");
        // string first_name = Console.ReadLine();
        // Console.Write("What is your last name?");
        // string last_name = Console.ReadLine();
        
        // Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");
    }
}