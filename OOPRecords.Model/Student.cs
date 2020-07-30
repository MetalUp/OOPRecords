using System;

namespace OOPRecords.Model
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;

            if (today.Month < DateOfBirth.Month || (today.Month == DateOfBirth.Month && today.Day < DateOfBirth.Day))
                age--;
            return age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age {Age()}";
        }
    }
}
