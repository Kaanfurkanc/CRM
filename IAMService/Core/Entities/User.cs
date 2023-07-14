using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("password")]
        public required string Password { get; set; }

        [BsonElement("username")]
        public required string Username { get; set; }

        [BsonElement("role")]
        public required string Role { get; set; }

        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("lastUpdatedDate")]
        public DateTime? LastUpdatedDate { get; set;}

        [BsonElement("lastSessionTime")]
        public DateTime? LastSessionTime { get; set; }
    }
}
