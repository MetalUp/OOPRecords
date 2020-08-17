Imports NakedObjects

Public Class SetRepository
    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    Public Function CreateNewSet() As TeachingSet
        Return _container.NewTransientInstance(Of TeachingSet)()
    End Function

    Public Function ListSets(<Optionally> ByVal subject As Subject, <Optionally> ByVal yearGroup As Integer?) As IQueryable(Of TeachingSet)
        Dim sets = _container.Instances(Of TeachingSet)()

        If subject IsNot Nothing Then
            Dim id As Integer = subject.Id
            sets = sets.Where(Function(s) s.Subject.Id = id)
        End If

        If yearGroup IsNot Nothing Then
            sets = sets.Where(Function(s) s.YearGroup = yearGroup.Value)
        End If

        Return sets.OrderBy(Function(s) s.YearGroup).ThenBy(Function(s) s.Subject.Name)
    End Function
End Class