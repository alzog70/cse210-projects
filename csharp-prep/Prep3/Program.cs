using System;

class Program
{
    static void Main(string[] args)
    {   
        
        // Console.Write("What is the magic number? ");
        // int magic_number = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int magic_number = randomGenerator.Next(1, 100);

        int guess =-1;

        while (guess != magic_number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());


            if (guess > magic_number)
                {
                    Console.WriteLine("Lower");
                }
            else if (guess < magic_number)
                {
                    Console.WriteLine("Higher");
                }
            
            else
                {
                    Console.WriteLine("You got it right!");
                }
        }
    }
}