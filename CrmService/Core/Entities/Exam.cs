using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Exam : BaseEntity
    {
        public string? ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string? ExamDescription { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public ICollection<Grade>? Grades { get; set; }
    }
}
