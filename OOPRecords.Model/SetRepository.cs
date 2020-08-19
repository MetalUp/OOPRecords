using NakedObjects;
using System.Linq;

namespace OOPRecords.Model
{
    public class SetRepository
    {
        public IDomainObjectContainer Container { set; protected get; }

        public TeachingSet CreateNewSet()
        {
            return Container.NewTransientInstance<TeachingSet>();
        }

        public IQueryable<TeachingSet> ListSets([Optionally] Subject subject, [Optionally] int? yearGroup)
        {
            var sets = Container.Instances<TeachingSet>();
            if (subject != null)
            {
                int id = subject.Id;
                sets = sets.Where(s => s.Subject.Id == id);
            }
            if (yearGroup != null)
            {
                sets = sets.Where(s => s.YearGroup == yearGroup.Value);
            }
            return sets.OrderBy(s => s.YearGroup).ThenBy(s => s.Subject.Name);
        }
    }
}
