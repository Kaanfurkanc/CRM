using Core.Entities;
using System.Linq.Expressions;

namespace Core.GenericRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(string id);
        Task<User> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersByRoleAsync(string role);
        IQueryable<User> Where(Expression<Func<User, bool>> expression);
        Task NewUserAsync(User user);
        Task UpdateUserAsync(string id, User user);
        Task DeleteUserAsync(string id);
    }
}
