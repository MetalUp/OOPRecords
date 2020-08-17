Imports NakedObjects


Public Class TeachingSet
    <NakedObjectsIgnore>
    Public Overridable Property Id As Integer

    <MemberOrder(1)>
    Public Overridable Property SetName As String

    <MemberOrder(2)>
    Public Overridable Property Subject As Subject

    <MemberOrder(3)> <ComponentModel.DataAnnotations.Range(9, 13)>
    Public Overridable Property YearGroup As Integer

    <MemberOrder(4)>
    Public Overridable Property Teacher As Teacher

    Private _students As ICollection(Of Student) = New List(Of Student)
    <MemberOrder(5)>
    Public Overridable Property Students() As ICollection(Of Student)
        Get
            Return _students
        End Get
        Set(value As ICollection(Of Student))
            _students = value
        End Set
    End Property

    Public Sub AddStudentToSet(ByVal student As Student)
        Students.Add(student)
    End Sub

    Public Sub RemoveStudentFromSet(ByVal student As Student)
        Students.Remove(student)
    End Sub

    Public Function Choices0RemoveStudentFromSet() As IList(Of Student)
        Return Students.ToList()
    End Function

    Public Overrides Function ToString() As String
        Return SetName
    End Function
End Class
