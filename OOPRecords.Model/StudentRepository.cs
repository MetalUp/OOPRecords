﻿using NakedObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace OOPRecords.Model
{
    public class StudentRepository
    {
        //private DbSet<Student> Students
        public IDomainObjectContainer Container { set; protected get; }
    
        //public StudentRepository(DatabaseContext context)
        //{
        //    Students = context.Students;
        //}

        public IQueryable<Student> AllStudents()
        {
            return Container.Instances<Student>();
        }

        public IQueryable<Student> FindStudentByLastName(string lastName)
        {
            return from s in AllStudents()
                   where s.LastName.ToUpper().Contains(lastName.ToUpper())
                   select s;
        }

        public Student NewStudent(string firstName, string lastName, DateTime dob)
        {
            var s = Container.NewTransientInstance<Student>();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = dob;
            //Students.Add(s);
            Container.Persist(ref s);
            return s;
        }
    }
}

