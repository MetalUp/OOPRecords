using System.Collections.Generic;

namespace OOPRecords.Model
{
    public class Teacher
    {
        public virtual int Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string LastName { get; set; }

        public virtual string JobTitle { get; set; }

        public virtual ICollection<Student> Tutees { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"{Title} {LastName}, {JobTitle}";
        }
    }
}
