Imports System.Data.Entity

Public Class DatabaseContext
    Inherits DbContext

    Public Sub New(ByVal dbName As String)
        MyBase.New(dbName)
        Database.SetInitializer(New Initializer())
    End Sub

    Public Property Students As DbSet(Of Student)
    Public Property Teachers As DbSet(Of Teacher)
    Public Property Subjects As DbSet(Of Subject)
    Public Property Sets As DbSet(Of TeachingSet)
    Public Property SubjectReports As DbSet(Of SubjectReport)
End Class