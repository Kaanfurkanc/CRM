using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class NewUserDTO : BaseDTO
    {
        public required string Password { get; set; }
        public required string Username { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public required string Role { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
    }
}
