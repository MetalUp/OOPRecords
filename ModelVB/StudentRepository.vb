Imports System.Data.Entity
Imports NakedObjects

Public Class StudentRepository
    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    Public Function AllStudents() As IQueryable(Of Student)
        Return _container.Instances(Of Student)()
    End Function

    Public Function FindStudentByLastName(ByVal lastName As String) As IQueryable(Of Student)
        Return From s In AllStudents()
               Where s.LastName.ToUpper().Contains(lastName.ToUpper())
               Select s
    End Function

    Public Function NewStudent(ByVal firstName As String, ByVal lastName As String, ByVal dob As DateTime) As Student
        Dim s = _container.NewTransientInstance(Of Student)
        s.FirstName = firstName
        s.LastName = lastName
        s.DateOfBirth = dob
        _container.Persist(s)
        Return s
    End Function

End Class
