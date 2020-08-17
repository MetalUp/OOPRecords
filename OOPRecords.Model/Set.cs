using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using NakedObjects;

namespace OOPRecords.Model
{
    public class Set
    {
        public IDomainObjectContainer Container { set; protected get; }

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        public virtual string SetName { get; set; }

        [MemberOrder(2)]
        public virtual Subject Subject { get; set; }

        [MemberOrder(3), Range(9,13)]
        public virtual int YearGroup { get; set; }

        [MemberOrder(4)]
        public virtual Teacher Teacher { get; set; }

        [MemberOrder(5)]
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();

        public void AddStudentToSet(Student student)
        {
            Students.Add(student);
        }

        public void RemoveStudentFromSet(Student student)
        {
            Students.Remove(student);
        }

        public IList<Student> Choices0RemoveStudentFromSet()
        {
            return Students.ToList();
        }

        public override string ToString()
        {
            return SetName;
        }
    }
}

