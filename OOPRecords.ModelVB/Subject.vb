Imports NakedObjects

Public Class Subject
    <Hidden(WhenTo.Always)>
    Public Overridable Property Id As Integer
    <MemberOrder(1)>
    Public Overridable Property Name As String

    Public Overrides Function ToString() As String
        Return Name
    End Function
End Class

