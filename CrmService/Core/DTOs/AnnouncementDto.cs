using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AnnouncementDto : BaseDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int SchoolId { get; set; }
    }
}
