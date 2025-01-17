using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int numberList = -1;

        while (numberList != 0)
        {
            Console.Write("Enter a list of numbers, type 0  when finsihed. ");
            string number_string = Console.ReadLine();
            numberList = int.Parse(number_string);

            if (numberList != 0)
            {
                numbers.Add(numberList);
            }
        }
        
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number; 
        }

        Console.WriteLine($"The sum of the numbers is: {sum}");
        
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];

        foreach (int number in numbers)
        {
            if (numberList > max)
            {
                max = number; 
            }
        }
        Console.WriteLine($"The maximum is: {max}");
    }
}