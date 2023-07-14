using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Class : BaseEntity
    {
        public string? ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}
