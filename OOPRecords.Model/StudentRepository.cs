using System;
using System.Collections.Generic;
using System.Linq;

namespace OOPRecords
{
    public class StudentRepository
    {
        private List<Student> Students = new List<Student>();

        public void Add(Student s)
        {
            Students.Add(s);
        }

        public List<Student> AllStudents()
        {
            return Students;
        }

        public List<Student> FindStudentByLastName(string lastName)
        {
            return Students.Where(s => s.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
        }

    }
}
