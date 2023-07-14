using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Teacher : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
