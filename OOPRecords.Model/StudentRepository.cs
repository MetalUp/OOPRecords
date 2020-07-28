using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace OOPRecords.Model
{
    public class StudentRepository
    {
        private List<Student> Students = new List<Student>();
        private string studentsFile;

        public StudentRepository(string studentsFile)
        {
            this.studentsFile = studentsFile;
        }

        public void Add(Student s)
        {
            Students.Add(s);
        }

        public IEnumerable<Student> AllStudents()
        {
            return Students;
        }

        public IEnumerable<Student> FindStudentByLastName(string lastName)
        {
            return from s in Students
                   where s.LastName.ToUpper().Contains(lastName.ToUpper())
                   select s;
        }

        public Student NewStudent(string firstName, string lastName, DateTime dob)
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = dob;
            Students.Add(s);
            SaveAll();
            return s;
        }

        public void Load()
        {

                using (StreamReader reader = new StreamReader(studentsFile))
                {
                    string json = reader.ReadToEnd();
                    Students = JsonSerializer.Deserialize<List<Student>>(json);
                }

        }

        public void SaveAll()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Students, options);
            using (StreamWriter writer = new StreamWriter(studentsFile))
            {
                writer.Write(json);
                writer.Flush();
            }
        }
    }
}

