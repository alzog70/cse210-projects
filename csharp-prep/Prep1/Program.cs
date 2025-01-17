using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        
            // Other Program #1
        Console.Write("What is your first name?");
        string first_name = Console.ReadLine();
        Console.Write("What is your last name?");
        string last_name = Console.ReadLine();
        
        Console.WriteLine($"Your name is {last_name}, {first_name} {last_name}.");
    }
}