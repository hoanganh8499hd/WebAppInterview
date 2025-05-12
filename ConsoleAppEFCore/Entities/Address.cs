using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEFCore.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        //Mỗi Address có thể thuộc về Student hoặc Teacher
        //Dùng 2 khóa ngoại: StudentId, TeacherId(nullable)
        //Quan hệ một-một với cả Student và Teacher(tuỳ đối tượng)
        
        //public int? StudentId { get; set; }
        //public Student Student { get; set; }

        //public int? TeacherId { get; set; }
        //public Teacher Teacher { get; set; }


        /// <summary>
        /// Lazy loading
        /// </summary>
        public int? StudentId { get; set; }
        public virtual Student Student { get; set; } //Marking the Property as Virtual to Support Lazy Loading
        public int? TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; } //Marking the Property as Virtual to Support Lazy Loading
    }
}
