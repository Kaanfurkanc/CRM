using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
     public class LoginDTO 
    {
        public string? UserName { get; set; }
        public string? Password{ get; set; }
        public DateTime? LastSessionTime { get; set; }
    }
}
