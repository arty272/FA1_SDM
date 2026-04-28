using System;

namespace BQ2_HomeAffairsDigitalIdentityProcessor
{
    public class CitizenProfile
    {
        // Properties
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; private set; }
        public string CitizenshipStatus { get; set; }

        // Constructor: accepts name, ID, citizenship; calculates age automatically
        public CitizenProfile(string fullName, string idNumber, string citizenshipStatus)
        {
            FullName = fullName;
            IDNumber = idNumber;
            CitizenshipStatus = citizenshipStatus;
            Age = CalculateAgeFromID(idNumber);
        }

        // Private method that extracts birth date from first 6 digits (YYMMDD)
        private int CalculateAgeFromID(string idNumber)
        {
            if (string.IsNullOrWhiteSpace(idNumber) || idNumber.Length < 6)
                return -1; // Invalid

            try
            {
                int yy = int.Parse(idNumber.Substring(0, 2));
                int mm = int.Parse(idNumber.Substring(2, 2));
                int dd = int.Parse(idNumber.Substring(4, 2));

                // Determine century based on current year
                int currentYear = DateTime.Now.Year;
                int currentTwoDigit = currentYear % 100;
                int century = (yy > currentTwoDigit) ? 1900 : 2000;
                int birthYear = century + yy;

                // Validate month and day ranges
                if (mm < 1 || mm > 12) return -1;
                int daysInMonth = DateTime.DaysInMonth(birthYear, mm);
                if (dd < 1 || dd > daysInMonth) return -1;

                DateTime birthDate = new DateTime(birthYear, mm, dd);
                if (birthDate > DateTime.Now) return -1;   // Future date invalid

                int age = DateTime.Now.Year - birthYear;
                if (DateTime.Now.DayOfYear < birthDate.DayOfYear) age--;

                return age;
            }
            catch
            {
                return -1;
            }
        }

        // ValidateID() method – returns descriptive message
        public string ValidateID()
        {
            // 1. Check length
            if (string.IsNullOrWhiteSpace(IDNumber))
                return "ID Number cannot be empty.";

            if (IDNumber.Length != 13)
                return $"ID Number must be exactly 13 digits. (Current length: {IDNumber.Length})";

            // 2. Check numeric
            if (!long.TryParse(IDNumber, out _))
                return "ID Number must contain only numeric characters.";

            // 3. Use calculated age (if negative, parsing or date failed)
            if (Age <= 0)
                return "Invalid ID: Birth date could not be parsed or is in the future.";

            if (Age >= 120)
                return "ID Number valid but age exceeds 120 – please verify.";

            return $"Valid ID. Citizen age: {Age} years.";
        }
    }
}