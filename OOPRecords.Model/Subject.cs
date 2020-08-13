using NakedObjects;

namespace OOPRecords.Model
{
    public class Subject
    {
        [Hidden(WhenTo.Always)]
        public virtual int Id { get; set; }

        [MemberOrder(1)]
        public virtual string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
