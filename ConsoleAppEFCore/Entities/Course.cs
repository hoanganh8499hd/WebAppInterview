using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Fees { get; set; }

        ////1 Course → nhiều Student (nhiều-nhiều)
        ////Student ↔ Course(Many-to-Many)
        //public ICollection<Student> Students { get; set; }

        ////1 Course → nhiều Subject (nhiều-nhiều)
        ////Course ↔ Subject(Many-to-Many)
        //public ICollection<Subject> Subjects { get; set; }


        /// <summary>
        /// Lazy loading
        /// </summary>

        public virtual ICollection<Student> Students { get; set; } //Marking the Property as Virtual to Support Lazy Loading
        public virtual ICollection<Subject> Subjects { get; set; } //Marking the Property as Virtual to Support Lazy Loading
    }
}
