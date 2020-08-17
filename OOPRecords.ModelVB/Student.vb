Imports System.ComponentModel.DataAnnotations
Imports NakedObjects

Public Class Student

    Private _teacherRep As TeacherRepository
    Public WriteOnly Property TeacherRepository() As TeacherRepository
        Set(ByVal value As TeacherRepository)
            _teacherRep = value
        End Set
    End Property

    Private _container As IDomainObjectContainer
    Public WriteOnly Property Container() As IDomainObjectContainer
        Set(ByVal value As IDomainObjectContainer)
            _container = value
        End Set
    End Property

    <Hidden(WhenTo.Always)>
    Public Overridable Property Id As Integer

    <MemberOrder(2)>
    Public Overridable Property FirstName As String

    <MemberOrder(3)>
    Public Overridable Property LastName As String

    <MemberOrder(4)> <Hidden(WhenTo.OncePersisted)>
    Public Overridable Property DateOfBirth As Date

    Public Function ValidateDateOfBirth(ByVal dob As DateTime) As String
        Return If(dob > DateTime.Today, "Date of Birth cannot be after today", Nothing)
    End Function

    Public Sub ConfirmDateOfBirth(ByVal dateOfBirth As DateTime)
        Dim message = If(dateOfBirth = dateOfBirth, "CORRECT", "INCORRECT")
        _container.InformUser($"The date of birth you entered is {message} for this student.")
    End Sub

    <MemberOrder(5)>
    Public Overridable Property Tutor As Teacher

    Public Function AutoCompleteTutor(<MinLength(3)> ByVal match As String) As IQueryable(Of Teacher)
        Return _teacherRep.FindTeacherByLastName(match)
    End Function

    <MemberOrder(1)>
    Public Overridable Property StudentNumber As String

    Private _sets As ICollection(Of TeachingSet) = New List(Of TeachingSet)

    <MemberOrder(6)>
    Public Overridable Property Sets() As ICollection(Of TeachingSet)
        Get
            Return _sets
        End Get
        Set(value As ICollection(Of TeachingSet))
            _sets = value
        End Set
    End Property

    <Hidden(WhenTo.Always)>
    Public Function Age() As Integer
        Dim today = Date.Today
        Dim ageToday As Integer = today.Year - DateOfBirth.Year
        If today.Month < DateOfBirth.Month OrElse (today.Month = DateOfBirth.Month AndAlso today.Day < DateOfBirth.Day) Then ageToday -= 1
        Return ageToday
    End Function

    Public Overrides Function ToString() As String
        Dim x = _teacherRep.AllTeachers()
        Return $"{FirstName} {LastName}, Age {Age()}"
    End Function
End Class
