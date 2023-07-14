using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class School : BaseEntity
    {
        public string? SchoolName { get; set; }
        public string? SchoolType { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Mail { get; set; }
        public Address? Address { get; set; }
        public ICollection<Class>? Classes { get; set; }
        public List<Announcement>? announcements { get; set; }
    }
}
