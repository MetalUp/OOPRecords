﻿using System;
using System.Data.Entity;

namespace OOPRecords.Model
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            var students = context.Students;
            var jj = NewStudent(students, "James", "Java", "24/03/2004", "HW531");
            var aa = NewStudent(students, "Alie", "Algol", "19/02/2004", "HM287");
            var ff = NewStudent(students, "Forrest", "Fortran", "22/09/2003", "LX046");
            NewStudent(students, "Simon", "Simula", "1/11/2003", "LY112");
            var teachers = context.Teachers;
            var hh = NewTeacher(teachers, "Harry", "Haskell", "Computer Science teacher");
            var bb = NewTeacher(teachers, "Bunny", "Bunsen", "Head of Chemistry");
            jj.Tutor = hh;
            aa.Tutor = hh;
            ff.Tutor = bb;
        }

        private Student NewStudent(DbSet<Student> students, string firstName, string lastName, string dob, string number)
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = Convert.ToDateTime(dob);
            s.StudentNumber = number;
            students.Add(s);
            return s;
        }

        private Teacher NewTeacher(DbSet<Teacher> teachers, string firstName, string lastName, string jobTitle)
        {
            var t = new Teacher();
            t.FirstName = firstName;
            t.LastName = lastName;
            t.JobTitle = jobTitle;
            teachers.Add(t);
            return t;
        }
    }
}
