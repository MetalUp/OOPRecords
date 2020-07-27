using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OOPRecords
{
    public class Initializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext dbc)
        {
            dbc.Students.Add(new Student(1, "James", "Java", new DateTime(2004, 5, 6)));
            dbc.Students.Add(new Student(2, "Alie", "Algol", new DateTime(2004, 3, 17)));
        }
    }
}
