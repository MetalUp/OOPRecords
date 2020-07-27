using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace OOPRecords
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(string dbName) : base(dbName)
        {
            Database.SetInitializer(new Initializer());
        }

        public DbSet<Student> Students { get; set; }
    }
}
