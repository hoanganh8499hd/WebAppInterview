using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class EFCoreDbContext : DbContext
    {

        //Constructor calling the Base DbContext Class Constructor
        public EFCoreDbContext() : base()
        {
            //Disabling Lazy Loading
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Enable Logging
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);


            //Enabling Lazy Loading
            //optionsBuilder.UseLazyLoadingProxies();


            //Connection String
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1435;Database=StudentDB;User Id=sa;Password=Passw0rd!;Multipleactiveresultsets=true;TrustServerCertificate=True;");
        }
        // DbSet properties represent the tables in the database. 
        // Each DbSet corresponds to a table, and the type parameter corresponds to the entity class mapped to that table.
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }

        //Do EF Core 5+ hỗ trợ tự động tạo bảng trung gian, nên những mối quan hệ nhiều-nhiều sẽ sinh ra các bảng sau:
        //| Bảng trung gian | Mối quan hệ giữa      |
        //| --------------- | --------------------- |
        //| CourseStudent   | `Course` ↔ `Student`  |
        //| CourseSubject   | `Course` ↔ `Subject`  |
        //| SubjectTeacher  | `Subject` ↔ `Teacher` |


        //Add-Migration CreatingStudentDatabase
        //Update-Database -Verbose

    }
}
