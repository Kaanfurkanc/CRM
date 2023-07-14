using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Announcement : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
        public School? School { get; set; }
    }
}
