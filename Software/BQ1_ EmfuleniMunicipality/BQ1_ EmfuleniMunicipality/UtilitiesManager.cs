using System;
using System.Collections.Generic;
using System.Text;

namespace BQ1__EmfuleniMunicipality
{
    internal class UtilitiesManager
    {
        public int CalculateUrgencyScore(ServiceRequest request)
        {
            return request.PriorityLevel * request.SeverityLevel;
        }

        public void GenerateReport(ServiceRequest request, int urgencyScore)
        {
            int adjusted = request.EstimatedResolutionHours + request.PriorityLevel;
            double householdImpact = request.AssociatedResident.MonthlyUtilityUsage * request.SeverityLevel;

            Console.WriteLine();
            Console.WriteLine("==== Service Report ====");
            Console.WriteLine($"Resident: {request.AssociatedResident.Name}");
            Console.WriteLine($"Service Type: {request.RequestType}");
            Console.WriteLine($"Urgency Score: {urgencyScore}");
            Console.WriteLine($"Adjusted Resolution: {adjusted} hours");
            Console.WriteLine($"Household Impact Score: {householdImpact:F2}");
        }
    }
}
