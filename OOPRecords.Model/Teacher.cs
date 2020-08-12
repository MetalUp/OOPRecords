using NakedObjects;
using System.Collections.Generic;
using System.Linq;

namespace OOPRecords.Model
{
    public class Teacher
    {
        public IDomainObjectContainer Container { set; protected get; }

        [Hidden(WhenTo.Always)]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        public virtual string Title { get; set; }

        [MemberOrder(2)]
        public virtual string LastName { get; set; }

        [MemberOrder(3), Optionally]
        public virtual string JobTitle { get; set; }

        [MemberOrder(4)]
        public virtual ICollection<Student> Tutees { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"{Title} {LastName}, {JobTitle}";
        }

        [MemberOrder(5)]
        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false, "Subject", "YearGroup", "SetName")]
        public virtual ICollection<Set> SetsTaught()
        {
            int id = this.Id;
            return Container.Instances<Set>().Where(s => s.Teacher.Id == id).OrderBy(s => s.Subject.Name).ThenBy(s => s.YearGroup).ToList();
        }
    }
}
