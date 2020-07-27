using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace OOPRecords
{
    public class StudentRepository
    {
        private DatabaseContext Context;

        public StudentRepository(DatabaseContext context)
        {
            Context = context;
        }

        public void Add(Student s)
        {
            Context.Students.Add(s);
        }

        public List<Student> AllStudents()
        {
            return Context.Students.ToList();
        }

        public Student FindStudentById(int id)
        {
            return AllStudents().Where(s => s.Id == id).FirstOrDefault();
        }

        public Student CreateNewStudent(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            Student s = new Student(id, firstName, lastName, dateOfBirth);
            Add(s);
            return s;
        }

    }
}
