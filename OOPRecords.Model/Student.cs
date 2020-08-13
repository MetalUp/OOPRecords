using NakedObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OOPRecords.Model
{
    public class Student
    {
        public TeacherRepository TeacherRepository { set; protected get; }

        public SubjectRepository SubjectRepository { set; protected get; }

        public IDomainObjectContainer Container { set; protected get; }


        [Hidden(WhenTo.Always)]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        public virtual string StudentNumber { get; set; }

        [MemberOrder(2)]
        public virtual string FirstName { get; set; }

        [MemberOrder(3)]
        public virtual string LastName { get; set; }

        [MemberOrder(4)][Hidden(WhenTo.OncePersisted)]
        public virtual DateTime DateOfBirth { get; set; }

        public void ConfirmDateOfBirth(DateTime dateOfBirth)
        {
            var message = dateOfBirth == DateOfBirth ? "CORRECT" : "INCORRECT";
            Container.InformUser($"The date of birth you entered is {message} for this student.");
        }

        public string ValidateDateOfBirth(DateTime dob)
        {
            return dob > DateTime.Today ? "Date of Birth cannot be after today" : null;
        }


        [MemberOrder(5)]
        public virtual Teacher Tutor { get; set; }

        public IQueryable<Teacher> AutoCompleteTutor([MinLength(3)] string match)
        {
            return TeacherRepository.FindTeacherByLastName(match);
        }


        [MemberOrder(6)]
        [Eagerly(EagerlyAttribute.Do.Rendering)]
        [TableView(false, "Subject", "SetName", "Teacher")]
        public virtual ICollection<Set> Sets { get; set; } = new List<Set>();

        [Hidden(WhenTo.Always)]
        public int Age()
        {
            var today = DateTime.Today;
            int age = today.Year - DateOfBirth.Year;

            if (today.Month < DateOfBirth.Month || (today.Month == DateOfBirth.Month && today.Day < DateOfBirth.Day))
                age--;
            return age;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age {Age()}";
        }

        public IQueryable<SubjectReport> ListRecentReports()
        {
            int id = this.Id;
            var studentReps = Container.Instances<SubjectReport>().Where(sr => sr.Student.Id == id);
            return studentReps.OrderByDescending(sr => sr.Date);
        }

        public SubjectReport CreateNewReport()
        {
            var rep = Container.NewTransientInstance<SubjectReport>();
            rep.Student = this;
            return rep;
        }
    }
}
