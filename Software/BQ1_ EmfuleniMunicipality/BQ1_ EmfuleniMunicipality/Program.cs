using BQ1__EmfuleniMunicipality;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to Emfuleni Municipality Service Desk ===");

        // ── Collect residents ─────────────────────────────────────────────
        int residentCount = ReadInt("How many residents do you want to register? ");
        var residents = new List<Resident>();

        for (int i = 1; i <= residentCount; i++)
        {
            Console.WriteLine($"\n--- Resident {i} ---");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Address: ");
            string address = Console.ReadLine();

            Console.Write("Account Number: ");
            string account = Console.ReadLine();

            double usage = ReadDouble("Monthly Utility Usage (kWh or litres): ");

            residents.Add(new Resident(name, address, account, usage));
        }

        // ── Collect service requests ──────────────────────────────────────
        int requestCount = ReadInt("\nHow many service requests do you want to log? ");
        var requests = new List<ServiceRequest>();
        var manager = new UtilitiesManager();

        for (int i = 1; i <= requestCount; i++)
        {
            Console.WriteLine($"\n  Service Request {i}");

            // Pick a resident
            Console.WriteLine("Select resident by number (1 to " + residents.Count + "): ");
            for (int r = 0; r < residents.Count; r++)
                Console.WriteLine($"  {r + 1}. {residents[r].Name}");

            int resChoice;
            do { resChoice = ReadInt("Choice: "); }
            while (resChoice < 1 || resChoice > residents.Count);

            Resident chosen = residents[resChoice - 1];

            Console.Write("Request Type (e.g., Water Outage, Burst Pipe): ");
            string reqType = Console.ReadLine();

            int priority, severity, hours;

            do { priority = ReadInt("Priority Level (1-5): "); }
            while (priority < 1 || priority > 5);

            do { severity = ReadInt("Severity Level (1-10): "); }
            while (severity < 1 || severity > 10);

            hours = ReadInt("Estimated Resolution Hours: ");

            var request = new ServiceRequest(reqType, priority, severity, hours, chosen);
            int urgencyScore = manager.CalculateUrgencyScore(request);

            // Show immediate report
            manager.GenerateReport(request, urgencyScore);

            requests.Add(request);
        }

        // ── Display queue ─────────────────────────────────────────────────
        Console.WriteLine("\n\n==== Pending Service Requests Queue ====");
        for (int i = 0; i < requests.Count; i++)
        {
            int score = manager.CalculateUrgencyScore(requests[i]);
            Console.WriteLine($"{i + 1}. [{requests[i].AssociatedResident.Name}] " +
                              $"{requests[i].RequestType} | Urgency: {score}");
        }

        // ── Interactive processing ────────────────────────────────────────
        Console.WriteLine("\nProcess requests by entering their number (0 to stop):");

        int highestScore = int.MinValue;
        ServiceRequest topRequest = null;
        var resolved = new List<ServiceRequest>();

        while (true)
        {
            int choice = ReadInt("Select request to process: ");
            if (choice == 0) break;
            if (choice < 1 || choice > requests.Count)
            {
                Console.WriteLine("Invalid selection.");
                continue;
            }

            ServiceRequest selected = requests[choice - 1];
            if (selected.IsProcessed)
            {
                Console.WriteLine("Already processed.");
                continue;
            }

            selected.IsProcessed = true;
            resolved.Add(selected);

            int score = manager.CalculateUrgencyScore(selected);
            Console.WriteLine($"Processing: {selected.RequestType} for " +
                              $"{selected.AssociatedResident.Name} | Score: {score}");

            if (score > highestScore)
            {
                highestScore = score;
                topRequest = selected;
            }
        }

        // ── Final summary ─────────────────────────────────────────────────
        Console.WriteLine("\n==== FINAL MUNICIPAL SUMMARY ====");
        Console.WriteLine("Resolved Requests:");

        foreach (var req in resolved)
        {
            int sc = manager.CalculateUrgencyScore(req);
            Console.WriteLine($"  - {req.AssociatedResident.Name}: " +
                              $"{req.RequestType} | Score: {sc}");
        }

        if (topRequest != null)
        {
            Console.WriteLine("\n==== Highest priority issue:");
            manager.GenerateReport(topRequest, highestScore);
        }

        Console.WriteLine("\nThank you for using the Emfuleni Municipality Service Desk.");
        Console.ReadKey();
    }

    // ── Helpers ───────────────────────────────────────────────────────────
    static int ReadInt(string prompt)
    {
        int value;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid. Enter a whole number: ");
        }
        return value;
    }

    static double ReadDouble(string prompt)
    {
        double value;
        Console.Write(prompt);
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid. Enter a numeric value: ");
        }
        return value;
    }
}