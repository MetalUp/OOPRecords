using System.Collections.Generic;

namespace OOPRecords.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public List<Student> Tutees { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {JobTitle}";
        }
    }
}
