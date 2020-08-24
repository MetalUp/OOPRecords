Imports System.Data.Entity

Public Class Initializer
    Inherits DropCreateDatabaseAlways(Of DatabaseContext)

    Protected Overrides Sub Seed(ByVal context As DatabaseContext)
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
End Class
