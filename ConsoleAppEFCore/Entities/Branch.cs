using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchLocation { get; set; }
        public string? BranchPhoneNumber { get; set; }
        public string? BranchEmail { get; set; }

        ////1 Branch → nhiều Student(một-nhiều)
        //public ICollection<Student> Students { get; set; }

        ////1 Branch → nhiều Teacher(một-nhiều)
        //public ICollection<Teacher> Teachers { get; set; }


        /// <summary>
        /// Lazy loading
        /// </summary>

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
