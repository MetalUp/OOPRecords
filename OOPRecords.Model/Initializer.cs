using System;

namespace OOPRecords.Model
{
    public class Initializer
    {
        public void Seed(StudentRepository students)
        {
            NewStudent(students, "James", "Java", "24/03/2004");
            NewStudent(students, "Alie", "Algol", "19/02/2004");
            NewStudent(students, "Forrest", "Fortran", "22/09/2003");
            NewStudent(students, "Simon", "Simula", "1/11/2003");
        }

        private Student NewStudent(StudentRepository students, string firstName, string lastName, string dob)
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dob);
            students.Add(s);
            return s;
        }
    }
}
