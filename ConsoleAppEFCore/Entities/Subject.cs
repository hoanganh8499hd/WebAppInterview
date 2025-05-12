using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleAppEFCore.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }

        ////1 Subject → nhiều Teacher (nhiều-nhiều)
        ////Teacher ↔ Subject(Many-to-Many)
        //public ICollection<Teacher> Teachers { get; set; }

        ////1 Subject → nhiều Course (nhiều-nhiều)
        ////Course ↔ Subject(Many-to-Many)
        //public ICollection<Course> Courses { get; set; }


        /// <summary>
        /// Lazy loading
        /// </summary>
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
