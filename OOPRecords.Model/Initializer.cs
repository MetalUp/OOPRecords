using System;
using System.Collections.Generic;
using System.Text;

namespace OOPRecords
{
    public class Initializer
    {
        private StudentRepository Students;

        public void Seed(StudentRepository Students)
        {
            NewStudent("James", "Java", "24/03/2004");
            NewStudent("Alie", "Algol", "19/02/2004");

        }

        private Student NewStudent(string firstName, string lastName, string dob)  
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dob);
            return s;
        }


    }
}
