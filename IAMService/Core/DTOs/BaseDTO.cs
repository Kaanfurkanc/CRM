using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class BaseDTO 
    {
        [BsonId]
        public string Id {  get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
