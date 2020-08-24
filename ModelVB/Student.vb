Public Class Student
    Public Overridable Property Id As Integer
    Public Overridable Property FirstName As String
    Public Overridable Property LastName As String
    Public Overridable Property DateOfBirth As Date
    Public Function ValidateDateOfBirth(ByVal dob As DateTime) As String
        Return If(dob > DateTime.Today, "Date of Birth cannot be after today", Nothing)
    End Function

    Public Overridable Property Tutor As Teacher
    Public Overridable Property StudentNumber As String

    Public Function Age() As Integer
        Dim today = Date.Today
        Dim ageToday As Integer = today.Year - DateOfBirth.Year
        If today.Month < DateOfBirth.Month OrElse (today.Month = DateOfBirth.Month AndAlso today.Day < DateOfBirth.Day) Then ageToday -= 1
        Return ageToday
    End Function

    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName}, Age {Age()}"
    End Function
End Class

