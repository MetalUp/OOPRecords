using System;
using System.Data.Entity;

namespace OOPRecords.Model
{
    public class Initializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {

        protected override void Seed(DatabaseContext context)
        {             
            #region  Teachers
            var teachers = context.Teachers;
            var de = NewTeacher(teachers, "Mr.","Deckerd");
            var dt = NewTeacher(teachers, "Dr.", "Tyrell");
            var mm = NewTeacher(teachers, "Maj.", "Major");
            var md = NewTeacher(teachers, "Mrs.", "Doubtfire");
            var dd = NewTeacher(teachers, "Dr.", "Doolittle");
            var ds = NewTeacher(teachers, "Dr.", "Strangelove");
            var mi = NewTeacher(teachers, "Ms.", "Issippi");
            var ma = NewTeacher(teachers, "Ms.", "Andrist");
            var dj = NewTeacher(teachers, "Dr.", "Jekyll");
            var mh = NewTeacher(teachers, "Mr.", "Hyde");
            var mr = NewTeacher(teachers, "Mrs.", "Robinson");
            var mw = NewTeacher(teachers, "Mrs.", "Worthington");
            var dh = NewTeacher(teachers, "Dr.", "Hu");
            var co = NewTeacher(teachers, "Cpt.", "Over");
            #endregion
            #region Students
            var students = context.Students;
            var aa = NewStudent(students, "Alie", "Algol", "19/02/2004", "HM287");
            var ff = NewStudent(students, "Forrest", "Fortran", "22/09/2003", "LX046");
            var jj = NewStudent(students, "James", "Java", "24/03/2004", "HW531");
            var cc = NewStudent(students, "Celia", "Cee-Sharp", "12/09/2003", "LX033");
            var vv = NewStudent(students, "Veronica", "Vee-Bee", "05/09/2003", "HM119");
            var ss = NewStudent(students, "Simon", "Simula", "31/07/2003", "HW309");
            var tt = NewStudent(students, "Tilly", "TypeScript", "14/01/2003", "LX008");
            var pp = NewStudent(students, "Petra", "Python", "17/06/2003", "LX 144");
            var hh = NewStudent(students, "Harry", "Haskell", "08/04/2003", "HM200");
            var cb = NewStudent(students, "Corinie","Cobol", "28/02/2003", "HW442");
            //assign tutors
            jj.Tutor = dd;
            aa.Tutor = mw;
            ff.Tutor = md;
            #endregion
            #region Subjects
            var subjects = context.Subjects;
            var csc = CreateNewSubject(subjects, "Computer Science");
            var math = CreateNewSubject(subjects, "Maths");
            var eng = CreateNewSubject(subjects, "English");
            var phy = CreateNewSubject(subjects, "Physics");
            var chem = CreateNewSubject(subjects, "Chemistry");
            var bio = CreateNewSubject(subjects, "Biology");
            var his = CreateNewSubject(subjects, "History");
            var fre = CreateNewSubject(subjects, "French");
            var ger = CreateNewSubject(subjects, "German");
            var dra = CreateNewSubject(subjects, "Drama");
            var des = CreateNewSubject(subjects, "Design & Technology");
            var film = CreateNewSubject(subjects, "Film Studies");
            var geo = CreateNewSubject(subjects, "Geography");
            #endregion
            #region Sets
            var sets = context.Sets;
            var CS12 = CreateNewSet(sets, "CS12", csc, 12, ds);
            var CS13 = CreateNewSet(sets, "CS13", csc, 13, ds);
            var MA09_1 = CreateNewSet(sets, "MA09_1", math, 9, ma);
            var MA10_1 = CreateNewSet(sets, "MA10_1", math, 10, ma);
            var MA11_1 = CreateNewSet(sets, "MA11_1", math, 11, ma);
            var MA09_2 = CreateNewSet(sets, "MA09_2", math, 9, dj);
            var MA10_2 = CreateNewSet(sets, "MA10_2", math, 10, dj);
            var MA11_2 = CreateNewSet(sets, "MA11_2", math, 11, dj);
            #endregion
            #region Make up sets
            AssignStudents(CS12, aa, cc, ff);
            AssignStudents(CS13, vv, ss);
            #endregion
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

        private Teacher NewTeacher(DbSet<Teacher> teachers, string title, string lastName)
        {
            var t = new Teacher();
            t.Title = title;
            t.LastName = lastName;
            teachers.Add(t);
            return t;
        }

        private Subject CreateNewSubject(DbSet<Subject> subjects, string name)
        {
            var obj = new Subject() { Name = name };
            subjects.Add(obj);
            return obj;
        }

        private Set CreateNewSet(DbSet<Set> sets, string name, Subject subject, int yearGroup, Teacher teacher)
        {
            var obj = new Set() { SetName = name, Subject = subject, YearGroup = yearGroup, Teacher = teacher };
            sets.Add(obj);
            return obj;
        }

        private SubjectReport CreateNewSubjectReport(DbSet<SubjectReport> subjectReports, Student st, Subject sub, string grade, Teacher teach, DateTime date)
        {
            var obj = new SubjectReport() { Student = st, Subject = sub, Grade = grade, GivenBy = teach, Date = date };
            subjectReports.Add(obj);
            return obj;
        }

        private void AssignStudents(Set set, params Student[] students)
        {
            foreach (Student stu in students)
            {
                set.Students.Add(stu);
            }
        }
    }
}
