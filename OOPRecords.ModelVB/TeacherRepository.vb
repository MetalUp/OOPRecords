

Imports NakedObjects

Public Class TeacherRepository
    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    Public Function AllTeachers() As IQueryable(Of Teacher)
        Return _container.Instances(Of Teacher)()
    End Function

    Public Function FindTeacherByLastName(ByVal lastName As String) As IQueryable(Of Teacher)
        Return From t In AllTeachers() Where t.LastName.ToUpper().Contains(lastName.ToUpper()) Select t
    End Function

    Public Function FindTeacherByJobTitle(ByVal job As String) As IQueryable(Of Teacher)
        Return From t In AllTeachers() Where t.JobTitle.ToUpper().Contains(job.ToUpper()) Select t
    End Function

    Public Function NewTeacher(ByVal title As String, ByVal lastName As String, ByVal job As String) As Teacher
        Dim t = _container.NewTransientInstance(Of Teacher)()
        t.Title = title
        t.LastName = lastName
        t.JobTitle = job
        _container.Persist(t)
        Return t
    End Function
End Class
