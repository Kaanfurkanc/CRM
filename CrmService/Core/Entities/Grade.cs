using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Grade : BaseEntity
    {
        public double Point { get; set; }
        public bool PassedStatus { get; set; }
        public int ExamId { get; set; }
        public Exam? Exam { get; set; }
    }
}
