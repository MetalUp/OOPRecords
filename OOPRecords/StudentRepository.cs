using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

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

        public Student FindStudentById(int id)
        {
            return Students.Where(s => s.Id == id).FirstOrDefault();
        }

    }
}
