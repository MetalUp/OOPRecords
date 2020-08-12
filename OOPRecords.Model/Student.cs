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

        [Hidden(WhenTo.Always)]
        public virtual int Id { get; set; }

        [MemberOrder(2)]
        public virtual string FirstName { get; set; }

        [MemberOrder(3)]
        public virtual string LastName { get; set; }

        [MemberOrder(4)]
        public virtual DateTime DateOfBirth { get; set; }

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

        [MemberOrder(1)]
        public virtual string StudentNumber { get; set; }

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
    }
}
