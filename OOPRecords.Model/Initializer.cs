using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace OOPRecords.Model
{
    public class Initializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        //private StudentRepository Students;
        private DatabaseContext Context;

        protected override void Seed(DatabaseContext context) //(StudentRepository students)
        {
            Context = context;
            //Students = students;
            NewStudent("James", "Java", "24/03/2004");
            NewStudent("Alie", "Algol", "19/02/2004");

        }

        private Student NewStudent(string firstName, string lastName, string dob)  
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dob);
            Context.Students.Add(s);
            return s;
        }
    }
}
