using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? CourseCode { get; set; }
        public string? Description { get; set; }
        public int Credit { get; set; }
        public int StudentId { get; set; }
        public ICollection<Exam>? exams { get; }
        public ICollection<Teacher>? Teachers { get; set; }
    }
}
