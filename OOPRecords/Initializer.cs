using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OOPRecords
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        private DatabaseContext Context;

        protected override void Seed(DatabaseContext context)
        {
            Context = context;
            CreateNewStudent("James", "Java", new DateTime(2004, 5, 6));
            CreateNewStudent("Alie", "Algol", new DateTime(2004, 3, 17));
        }

        private Student CreateNewStudent(string firstName, string lastName, DateTime dob)
        {
            var s = new Student() { FirstName = firstName, LastName = lastName, DateOfBirth = dob };
            Context.Students.Add(s);
            return s;
        }
    }
}
