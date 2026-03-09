using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine() ?? "0";

            if (!int.TryParse(input, out int number))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (number == 0)
            {
                break;
            }

            numbers.Add(number);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        int largest = numbers[0];

        foreach (int value in numbers)
        {
            sum += value;

            if (value > largest)
            {
                largest = value;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");

        int smallestPositive = int.MaxValue;
        foreach (int value in numbers)
        {
            if (value > 0 && value < smallestPositive)
            {
                smallestPositive = value;
            }
        }

        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int value in numbers)
        {
            Console.WriteLine(value);
        }
    }
}