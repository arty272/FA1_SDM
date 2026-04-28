using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();

        double[] marks = new double[3];

        for (int i = 1; i <= 3; i++)
        {
            while (true)
            {
                Console.Write($"Enter mark for Subject {i}: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out marks[i - 1]))
                    break;
                else
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }

        double total = marks[0] + marks[1] + marks[2];
        double average = total / 3;
        string result = average >= 50 ? "PASS" : "FAIL";

        Console.WriteLine();
        Console.WriteLine("===== STUDENT RESULTS =====");
        Console.WriteLine($"Student Name: {name}");
        Console.WriteLine($"Total Marks: {total}");
        Console.WriteLine($"Average Marks: {average:F1}");
        Console.WriteLine($"Result: {result}");
        Console.WriteLine($"Result Issued At: {DateTime.Now:dd MMM yyyy HH:mm:ss}");
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}