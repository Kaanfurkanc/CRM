using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class SchoolDto : BaseDto
    {
        public string? SchoolName { get; set; }
        public string? SchoolType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
    }
}
