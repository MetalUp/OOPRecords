using NakedObjects;
using System.Collections.Generic;

namespace OOPRecords.Model
{
    public class Teacher
    {
        [Hidden(WhenTo.Always)]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        public virtual string FirstName { get; set; }

        [MemberOrder(2)]
        public virtual string LastName { get; set; }

        [MemberOrder(3)]
        public virtual string JobTitle { get; set; }

        [MemberOrder(4)]
        public virtual ICollection<Student> Tutees { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {JobTitle}";
        }
    }
}
