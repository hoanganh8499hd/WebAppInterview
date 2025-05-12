using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// EagerLoading
        /// </summary>
        
        ////1 Student → 1 Branch(nhiều-sang-một)  (1 Branch có 1-nhiều Student)
        //public int BranchId { get; set; }
        //public Branch Branch { get; set; }

        ////1 Student → 1 Address(một-một)
        //public Address Address { get; set; }

        ////1 Student → nhiều Course (nhiều-nhiều qua bảng trung gian CourseStudent)
        ////Student ↔ Course(Many-to-Many)
        //public ICollection<Course> Courses { get; set; }

        /// <summary>
        /// Lazy loading
        /// </summary>

        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; } //Marking the Property as Virtual to Support Lazy Loading
        public virtual Address Address { get; set; } //Marking the Property as Virtual to Support Lazy Loading
        public virtual ICollection<Course> Courses { get; set; } //Marking the Property as Virtual to Support Lazy Loading
    }
}
