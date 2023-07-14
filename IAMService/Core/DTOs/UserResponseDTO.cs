using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class UserResponseDTO : BaseDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public required string Username { get; set; }
        public required string Role { get; set; }
    }
}
