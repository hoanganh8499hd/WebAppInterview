using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        ////1 Teacher → 1 Branch  (nhiều-sang-một)  (1 Branch có 1-N Teacher)
        ////Vì vậy, đây là quan hệ 1-N (one-to-many):
        ////Branch là "1"
        ////Teacher là "many"

        //public int BranchId { get; set; }
        //public Branch Branch { get; set; }

        ////1 Teacher → 1 Address (một-một)
        //public Address Address { get; set; }

        ////1 Teacher → nhiều Subject(nhiều-nhiều qua bảng trung gian SubjectTeacher)
        ////Teacher ↔ Subject(Many-to-Many)
        //public ICollection<Subject> Subjects { get; set; }


        /// <summary>
        /// Lazy loading
        /// </summary>
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
