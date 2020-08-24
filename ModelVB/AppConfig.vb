Imports System.Data.Entity

Public Module AppConfig
    Function Services() As Type()
        Return {GetType(StudentRepository)}
    End Function

    Function MainMenus() As IDictionary(Of String, Type)
        Return New Dictionary(Of String, Type)() From
             {{"Students", GetType(StudentRepository)}}
    End Function

    Function CreateDbContext() As DbContext
        Return New DatabaseContext("OOPRecords")
    End Function
End Module
