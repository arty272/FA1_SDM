using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("===== CTU SIMPLE ATM SYSTEM =====");
        Console.WriteLine();
        Console.WriteLine("HI , WHAT IS YOUR NAME?");
        string name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"WELCOME {name.ToUpper()}!");

        double balance;
        while (true)
        {
            Console.Write("Enter account balance: ");
            if (double.TryParse(Console.ReadLine(), out balance))
                break;
            Console.WriteLine("Invalid input. Please enter a numeric value.");
        }

        double withdrawal;
        while (true)
        {
            Console.Write("Enter withdrawal amount: ");
            if (double.TryParse(Console.ReadLine(), out withdrawal))
            {
                if (withdrawal > balance)
                    Console.WriteLine("Insufficient funds. Try a lower amount.");
                else if (withdrawal <= 0)
                    Console.WriteLine("Amount must be greater than zero.");
                else
                    break;
            }
            else
                Console.WriteLine("Invalid input. Please enter a numeric value.");
        }

        balance -= withdrawal;

        Console.WriteLine();
        Console.WriteLine("Withdrawal successful!");
        Console.WriteLine($"Updated Balance: {balance:F2}");
        Console.WriteLine($"Transaction Time: {DateTime.Now:dd MMM yyyy HH:mm:ss}");
        Console.WriteLine();
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}