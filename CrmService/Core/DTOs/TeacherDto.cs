using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class TeacherDto : BaseDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Department { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime BirtDate { get; set; }
        public int CourseId { get; set; }
    }
}
