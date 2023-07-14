using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class GradeDto : BaseDto
    {
        public double Point { get; set; }
        public bool PassedStatus { get; set; }
        public int ExamId { get; set; }
    }
}
