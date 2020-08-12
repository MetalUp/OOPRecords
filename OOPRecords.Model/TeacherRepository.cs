using NakedObjects;
using System.Linq;

namespace OOPRecords.Model
{
public class TeacherRepository
{

        public IDomainObjectContainer Container { set; protected get; }

        public IQueryable<Teacher> AllTeachers()
        {
            return Container.Instances<Teacher>();
        }

        public IQueryable<Teacher> FindTeacherByLastName(string lastName)
        {
            return from t in AllTeachers()
                   where t.LastName.ToUpper().Contains(lastName.ToUpper())
                   select t;
        }

        public IQueryable<Teacher> FindTeacherByJobTitle(string job)
        {
            return from t in AllTeachers()
                   where t.JobTitle.ToUpper().Contains(job.ToUpper())
                   select t;
        }

        public Teacher NewTeacher(string title, string lastName, string job)
        {
            var t = Container.NewTransientInstance<Teacher>();
            t.Title = title;
            t.LastName = lastName;
            t.JobTitle = job;
            Container.Persist(ref t);
            return t;
        }
    }
}
