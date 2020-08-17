Imports System.Data.Entity

Public Module AppConfig
    Function Services() As Type()
        Return {
            GetType(StudentRepository),
            GetType(TeacherRepository),
            GetType(SubjectRepository),
            GetType(SetRepository)
            }
    End Function

    Function MainMenus() As IDictionary(Of String, Type)
        Return New Dictionary(Of String, Type)() From
            {
                {"Students", GetType(StudentRepository)},
                {"Staff", GetType(TeacherRepository)},
                {"Subjects", GetType(SubjectRepository)},
                {"Sets", GetType(SetRepository)}
            }
    End Function

    Function CreateDbContext() As DbContext
        Return New DatabaseContext("OOPRecords")
    End Function
End Module