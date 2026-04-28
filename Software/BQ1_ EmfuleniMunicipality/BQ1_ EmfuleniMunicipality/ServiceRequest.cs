using System;
using System.Collections.Generic;
using System.Text;

namespace BQ1__EmfuleniMunicipality
{
    internal class ServiceRequest
    {
        public string RequestType { get; set; }
        public int PriorityLevel { get; set; }   // 1–5
        public int SeverityLevel { get; set; }   // 1–10
        public int EstimatedResolutionHours { get; set; }
        public Resident AssociatedResident { get; set; }
        public bool IsProcessed { get; set; }

        public ServiceRequest(string requestType, int priorityLevel,
                              int severityLevel, int estimatedHours,
                              Resident resident)
        {
            RequestType = requestType;
            PriorityLevel = priorityLevel;
            SeverityLevel = severityLevel;
            EstimatedResolutionHours = estimatedHours;
            AssociatedResident = resident;
            IsProcessed = false;
        }
    }
}
