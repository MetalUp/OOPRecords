using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OOPRecords.Model
{
    public class SubjectReport 
    {
        #region Injected Services
        public StudentRepository Students { set; protected get; }

        public TeacherRepository Teachers { set; protected get; }

        public SubjectRepository Subjects { set; protected get; }
        #endregion

        [NakedObjectsIgnore]
        public virtual int Id { get; set; }

        [MemberOrder(1), Disabled]
        public virtual Student Student { get; set; }

        [MemberOrder(2)]
        public virtual Subject Subject { get; set; }

        public IQueryable<Subject> AutoCompleteSubject()
        {
            return Subjects.AllSubjects();
        }

        [MemberOrder(3)]
        public virtual string Grade { get; set; }


        public IList<string> ChoicesGrade()
        {
            return new List<string> { "A*", "A", "B", "C", "D", "E", "U" };
        }

        [MemberOrder(4)]
        public virtual Teacher GivenBy { get; set; }

        public IList<Teacher> ChoicesGivenBy()
        {
            return Teachers.AllTeachers().ToList();
        }

        [MemberOrder(5)]
        [Mask("d")]
        public virtual DateTime Date { get; set; }

        public DateTime DefaultDate()
        {
            return DateTime.Today;
        }

        [MemberOrder(6)]
        [MultiLine][Optionally]
        public virtual string Notes { get; set; }

        public override string ToString()
        {
            return $"{Subject}, {Date.Date}";
        }
    }
}
