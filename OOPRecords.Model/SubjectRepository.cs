using NakedObjects;
using System.Linq;

namespace OOPRecords.Model
{
    public class SubjectRepository
    {
        public IDomainObjectContainer Container { set; protected get; }

        public Subject CreateNewSubject()
        {
            return Container.NewTransientInstance<Subject>();
        }

        public IQueryable<Subject> AllSubjects()
        {
            return Container.Instances<Subject>();
        }

        public IQueryable<Subject> FindSubjectByName(string name)
        {
            return AllSubjects().Where(c => c.Name.ToUpper().Contains(name.ToUpper()));
        }
    }
}
