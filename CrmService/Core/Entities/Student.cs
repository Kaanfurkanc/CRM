using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student  : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int StudentNo { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public int ClassId { get; set; }
        public Class? Class { get; set; }
        public ICollection<Course>? Courses { get; set; }
    }
}
