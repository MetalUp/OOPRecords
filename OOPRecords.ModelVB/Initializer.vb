Imports System.Data.Entity

Public Class Initializer
    Inherits DropCreateDatabaseAlways(Of DatabaseContext)

    Protected Overrides Sub Seed(context As DatabaseContext)
        Dim students = context.Students
        Dim alg = NewStudent(students, "Alie", "Algol", "19/02/2004", "HM287")
        Dim frt = NewStudent(students, "Forrest", "Fortran", "22/09/2003", "LX046")
        Dim jav = NewStudent(students, "James", "Java", "24/03/2004", "HW531")
        Dim cee = NewStudent(students, "Celia", "Cee-Sharp", "12/09/2003", "LX033")
        Dim vee = NewStudent(students, "Veronica", "Vee-Bee", "05/09/2003", "HM119")
        Dim sim = NewStudent(students, "Simon", "Simula", "31/07/2003", "HW309")
        Dim typ = NewStudent(students, "Tilly", "TypeScript", "14/01/2003", "LX008")
        Dim pyt = NewStudent(students, "Petra", "Python", "17/06/2003", "LX 144")
        Dim has = NewStudent(students, "Harry", "Haskell", "08/04/2003", "HM200")
        Dim cob = NewStudent(students, "Corinie", "Cobol", "28/02/2003", "HW442")

        Dim teachers = context.Teachers
        Dim dec = NewTeacher(teachers, "Mr.", "Deckerd")
        Dim tyr = NewTeacher(teachers, "Dr.", "Tyrell")
        Dim maj = NewTeacher(teachers, "Maj.", "Major")
        Dim dou = NewTeacher(teachers, "Mrs.", "Doubtfire")
        Dim doo = NewTeacher(teachers, "Dr.", "Doolittle")
        Dim str = NewTeacher(teachers, "Dr.", "Strangelove")
        Dim iss = NewTeacher(teachers, "Ms.", "Issippi")
        Dim [and] = NewTeacher(teachers, "Ms.", "Andrist")
        Dim jek = NewTeacher(teachers, "Dr.", "Jekyll")
        Dim hyd = NewTeacher(teachers, "Mr.", "Hyde")
        Dim rob = NewTeacher(teachers, "Mrs.", "Robinson")
        Dim wor = NewTeacher(teachers, "Mrs.", "Worthington")
        Dim hu = NewTeacher(teachers, "Dr.", "Hu")
        Dim ove = NewTeacher(teachers, "Cpt.", "Over")
        alg.Tutor = dec
        frt.Tutor = tyr
        jav.Tutor = maj

        Dim subjects = context.Subjects
        Dim csc = CreateNewSubject(subjects, "Computer Science")
        Dim math = CreateNewSubject(subjects, "Maths")
        Dim eng = CreateNewSubject(subjects, "English")
        Dim phy = CreateNewSubject(subjects, "Physics")
        Dim chem = CreateNewSubject(subjects, "Chemistry")
        Dim bio = CreateNewSubject(subjects, "Biology")
        Dim his = CreateNewSubject(subjects, "History")
        Dim fre = CreateNewSubject(subjects, "French")
        Dim ger = CreateNewSubject(subjects, "German")

        Dim sets = context.Sets
        Dim CS12 = CreateNewSet(sets, "CS12", csc, 12, dec)
        Dim CS13 = CreateNewSet(sets, "CS13", csc, 13, dec)
        Dim MA09_1 = CreateNewSet(sets, "MA09_1", math, 9, rob)
        Dim MA10_1 = CreateNewSet(sets, "MA10_1", math, 10, rob)
        Dim MA11_1 = CreateNewSet(sets, "MA11_1", math, 11, hu)
        Dim MA09_2 = CreateNewSet(sets, "MA09_2", math, 9, dou)
        Dim MA10_2 = CreateNewSet(sets, "MA10_2", math, 10, dou)
        Dim MA11_2 = CreateNewSet(sets, "MA11_2", math, 11, dou)

        AssignStudents(CS12, alg, cee, frt)
        AssignStudents(CS13, vee, sim)

    End Sub

    Private Function NewStudent(ByVal students As DbSet(Of Student), ByVal firstName As String, ByVal lastName As String, ByVal dob As String, ByVal number As String) As Student
        Dim s = New Student()
        s.FirstName = firstName
        s.LastName = lastName
        s.DateOfBirth = Convert.ToDateTime(dob)
        s.StudentNumber = number
        students.Add(s)
        Return s
    End Function

    Private Function NewTeacher(ByVal teachers As DbSet(Of Teacher), ByVal title As String, ByVal lastName As String) As Teacher
        Dim t = New Teacher()
        t.Title = title
        t.LastName = lastName
        teachers.Add(t)
        Return t
    End Function

    Private Function CreateNewSubject(ByVal subjects As DbSet(Of Subject), ByVal name As String) As Subject
        Dim obj = New Subject() With {
            .Name = name
        }
        subjects.Add(obj)
        Return obj
    End Function

    Private Function CreateNewSet(ByVal sets As DbSet(Of TeachingSet), ByVal name As String, ByVal subject As Subject, ByVal yearGroup As Integer, ByVal teacher As Teacher) As TeachingSet
        Dim obj = New TeachingSet() With {
            .SetName = name,
            .Subject = subject,
            .YearGroup = yearGroup,
            .Teacher = teacher
        }
        sets.Add(obj)
        Return obj
    End Function

    Private Sub AssignStudents(ByVal [set] As TeachingSet, ParamArray students As Student())
        For Each stu As Student In students
            [set].Students.Add(stu)
        Next
    End Sub

End Class
