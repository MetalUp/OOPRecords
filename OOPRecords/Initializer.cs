using System;
using System.Collections.Generic;
using System.Text;

namespace OOPRecords
{
    public class Initializer
    {
        public void Seed(StudentRepository Students)
        {
            Students.Add(new Student(1, "James", "Java", new DateTime(2004, 5, 6)));
            Students.Add(new Student(2, "Alie", "Algol", new DateTime(2004, 3, 17)));
        }
    }
}
