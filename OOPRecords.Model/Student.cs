using System;

namespace OOPRecords
{
    public class Student
    {
        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual DateTime DateOfBirth { get; set; }

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
