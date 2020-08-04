﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;

namespace OOPRecords.Model
{
public class StudentRepository
{
    private DbSet<Student> Students;

        public StudentRepository(DatabaseContext context)
        {
            Students = context.Students;
        }

        public void Add(Student s)
        {
            Students.Add(s);
        }

        public IQueryable<Student> AllStudents()
        {
            return Students;
        }

        public IQueryable<Student> FindStudentByLastName(string lastName)
        {
            return from s in AllStudents()
                   where s.LastName.ToUpper().Contains(lastName.ToUpper())
                   select s;
        }

        public Student NewStudent(string firstName, string lastName, DateTime dob)
        {
            var s = new Student();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = dob;
            Add(s);
            return s;
        }

    }
}
