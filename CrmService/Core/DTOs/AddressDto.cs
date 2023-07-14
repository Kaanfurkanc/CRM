using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class AddressDto : BaseDto
    {
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Description { get; set; }
        public string? PostCode { get; set; }
        public int SchoolId { get; set; }
    }
}

