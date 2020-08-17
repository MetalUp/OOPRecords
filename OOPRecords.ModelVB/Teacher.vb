Imports NakedObjects

Public Class Teacher
    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    <Hidden(WhenTo.Always)>
    Public Overridable Property Id As Integer

    <MemberOrder(1)>
    Public Overridable Property Title As String

    <MemberOrder(2)>
    Public Overridable Property LastName As String

    <MemberOrder(3)>
    Public Overridable Property JobTitle As String

    <MemberOrder(4)>
    Public Overridable Property Tutees() As ICollection(Of Student)

    <MemberOrder(5)> <Eagerly(EagerlyAttribute.[Do].Rendering)>
    <TableView(False, "Subject", "YearGroup", "SetName")>
    Public Overridable Function SetsTaught() As ICollection(Of TeachingSet)
        Dim id As Integer = Me.Id
        Return _container.Instances(Of TeachingSet)().Where(Function(s) s.Teacher.Id = id).OrderBy(Function(s) s.Subject.Name).ThenBy(Function(s) s.YearGroup).ToList()
    End Function


    Public Overrides Function ToString() As String
        Return $"{Title} {LastName}, {JobTitle}"
    End Function
End Class
