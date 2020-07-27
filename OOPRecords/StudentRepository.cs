using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using NakedObjects;

namespace OOPRecords
{
    public class StudentRepository
    {

        public IDomainObjectContainer Container { set; protected get; }


        public IQueryable<Student> AllStudents()
        {
            return Container.Instances<Student>();
        }

        public Student FindStudentById(int id)
        {
            return AllStudents().Where(s => s.Id == id).FirstOrDefault();
        }

        public Student CreateNewStudent(int id, string firstName, string lastName, DateTime dateOfBirth)
        {
            var s = Container.NewTransientInstance<Student>();
            s.FirstName = firstName;
            s.LastName = lastName;
            s.DateOfBirth = dateOfBirth;
            Container.Persist(ref s);
            return s;
        }

    }
}
