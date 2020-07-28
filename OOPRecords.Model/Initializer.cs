using System;
using System.Data.Entity;

namespace OOPRecords.Model
{
    public class Initializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
           var students = context.Students;
            var jj =NewStudent(students, "James", "Java", "24/03/2004");
            var aa =NewStudent(students, "Alie", "Algol", "19/02/2004");
            var mc = NewStudent(students, "Molly", "Cule", "05/05/2004");
            var teachers = context.Teachers;
           var hh = NewTeacher(teachers, "Harry", "Haskell", "Computer Science teacher");
           var bb = NewTeacher(teachers, "Bunny", "Bunsen", "Head of Chemistry");
            jj.Tutor = hh;
            aa.Tutor = hh;
            mc.Tutor = bb;
        }

        private Student NewStudent(DbSet<Student> students, string firstName, string lastName, string dob)  
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dob);
            students.Add(s);
            return s;
        }

        private Teacher NewTeacher(DbSet<Teacher> teachers, string firstName, string lastName, string jobTitle)
        {
            var t = new Teacher();
            t.FirstName = firstName;
            t.LastName = lastName;
            t.JobTitle = jobTitle;
            teachers.Add(t);
            return t;
        }
    }
}
