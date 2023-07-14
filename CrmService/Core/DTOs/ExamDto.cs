using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class ExamDto : BaseDto
    {
        public string? ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public string? ExamDescription { get; set; }
        public int CourseId { get; set; }
    }
}
