Imports NakedObjects

Public Class SubjectRepository

    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    Public Function CreateNewSubject() As Subject
        Return _container.NewTransientInstance(Of Subject)()
    End Function

    Public Function AllSubjects() As IQueryable(Of Subject)
        Return _container.Instances(Of Subject)()
    End Function

    Public Function FindSubjectByName(ByVal name As String) As IQueryable(Of Subject)
        Return AllSubjects().Where(Function(c) c.Name.ToUpper().Contains(name.ToUpper()))
    End Function
End Class
