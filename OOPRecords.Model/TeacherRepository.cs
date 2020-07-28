using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace OOPRecords.Model
{
    public class TeacherRepository
    {
        private DbSet<Teacher> Teachers;

        public TeacherRepository(DatabaseContext context)
        {
            Teachers = context.Teachers;
        }

        public IEnumerable<Teacher> AllTeachers()
        {
            return Teachers;
        }

        public IEnumerable<Teacher> FindTeacherByLastName(string lastName)
        {
            return from s in Teachers
                   where s.LastName.ToUpper().Contains(lastName.ToUpper())
                   select s;
        }

        public Teacher NewTeacher(string firstName, string lastName, string jobTitle)
        {
            var s = new Teacher();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.JobTitle = jobTitle;
            Teachers.Add(s);
            return s;
        }
    }
}

