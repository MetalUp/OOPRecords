Imports NakedObjects

Public Class SubjectReport

    Private _teacherRep As TeacherRepository
    Public WriteOnly Property TeacherRepository() As TeacherRepository
        Set(ByVal value As TeacherRepository)
            _teacherRep = value
        End Set
    End Property

    Private _subjectRep As SubjectRepository
    Public WriteOnly Property SubjectRepository() As SubjectRepository
        Set(ByVal value As SubjectRepository)
            _subjectRep = value
        End Set
    End Property


    <Hidden(WhenTo.Always)>
    Public Overridable Property Id As Integer

    <MemberOrder(1)> <Disabled>
    Public Overridable Property Student As Student

    <MemberOrder(2)>
    Public Overridable Property Subject As Subject

    Public Function AutoCompleteSubject(ByVal match As String) As IQueryable(Of Subject)
        Return _subjectRep.FindSubjectByName(match)
    End Function

    <MemberOrder(3)>
    Public Overridable Property Grade As String

    Public Function ChoicesGrade() As IList(Of String)
        Return New List(Of String) From {"A*", "A", "B", "C", "D", "E", "U"}
    End Function

    <MemberOrder(4)>
    Public Overridable Property GivenBy As Teacher

    Public Function ChoicesGivenBy() As IList(Of Teacher)
        Return _teacherRep.AllTeachers().ToList()
    End Function

    <MemberOrder(5)>
    <Mask("d")>
    Public Overridable Property OnDate As Date

    Public Function DefaultDate() As Date
        Return Date.Today
    End Function

    <MemberOrder(6)> <MultiLine> <Optionally>
    Public Overridable Property Notes As String

    Public Overrides Function ToString() As String
        Return $"{Subject}, {OnDate}"
    End Function
End Class