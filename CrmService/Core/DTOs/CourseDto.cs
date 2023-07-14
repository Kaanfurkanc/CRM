using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class CourseDto : BaseDto
    {
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public string? Description { get; set; }
        public int Credit { get; set; }
        public int StudentId { get; set; }
    }
}
