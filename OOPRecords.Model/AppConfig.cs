using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace OOPRecords.Model
{
    public class AppConfig
    {
        public static Type[] Services()
        {
            return new[] {
                    typeof(StudentRepository),
                    typeof(TeacherRepository),
                    typeof(SubjectRepository),
                    typeof(SetRepository),
                };
        }

        public static IDictionary<string, Type> MainMenus()
        {
            return new Dictionary<string, Type>()
            {
                ["Students"] = typeof(StudentRepository),
                ["Staff"] = typeof(TeacherRepository),
                ["Subjects"] = typeof(SubjectRepository),
                ["Sets"] = typeof(SetRepository),
            };
        }

        public static DbContext CreateDbContext()
        {
            return new DatabaseContext("OOPRecords");
        }
    }
}
