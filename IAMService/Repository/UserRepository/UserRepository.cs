using Core.Entities;
using Core.GenericRepository;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _userCollection;
        private readonly MongoDBSettings _mongoDBSettings;

        public UserRepository(IOptions<MongoDBSettings> settings)
        {
            _mongoDBSettings = settings.Value;
            var client = new MongoClient(_mongoDBSettings.ConnectionString);
            var database = client.GetDatabase(_mongoDBSettings.DatabaseName);
            _userCollection = database.GetCollection<User>("User");

        }
        public async Task DeleteUserAsync(string id)
        {
            var filter = Builders<User>.Filter.Eq(_ => _.Id, id);
            await _userCollection.DeleteOneAsync(filter);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await _userCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userCollection.Find(_ => _.Username == username).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(string role)
        {
            var filter = Builders<User>.Filter.Eq(_ => _.Role, role);
            return await _userCollection.Find(filter).ToListAsync();
        }

        public async Task NewUserAsync(User user)
        {
            await _userCollection.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(string id, User user)
        {
            await _userCollection.ReplaceOneAsync(_ => _.Id == id, user);
        }

        public IQueryable<User> Where(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
