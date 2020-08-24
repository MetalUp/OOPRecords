Public Class Teacher
    Public Overridable Property Id As Integer
    Public Overridable Property Title As String
    Public Overridable Property LastName As String
    Public Overridable Property JobTitle As String
    Private _tutees As ICollection(Of Student) = New List(Of Student)
    Public Overridable Property Tutees() As ICollection(Of Student)
        Get
            Return _tutees
        End Get
        Set(value As ICollection(Of Student))
            _tutees = value
        End Set
    End Property


    Public Overrides Function ToString() As String
        Return $"{Title} {LastName}, {JobTitle}"
    End Function
End Class
