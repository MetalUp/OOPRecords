using System;
using System.Collections.Generic;

namespace OOPRecords.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public  string FirstName { get; set; }

        public  string LastName { get; set; }

        public string JobTitle { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {JobTitle}";
        }

        public  ICollection<Student> Tutees { get; set; } = new List<Student>();

    }
}
