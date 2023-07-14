using Core.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class MongoDBContext
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly MongoDBSettings _mongoDBSettings;
        
        public MongoDBContext(IOptions<MongoDBSettings> settings)
        {
            _mongoDBSettings = settings.Value;
            var client = new MongoClient(_mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(_mongoDBSettings.DatabaseName);
            _userCollection = database.GetCollection<User>("User");
        }

    }
}
