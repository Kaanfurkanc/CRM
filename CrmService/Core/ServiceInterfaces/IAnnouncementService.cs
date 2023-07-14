using Core.DTOs;
using Core.Entities;
using System.Linq.Expressions;

namespace Core.ServiceInterfaces
{
    public interface IAnnouncementService
    {
        Task<IEnumerable<Announcement>> GetAllAsync();
        Task<Announcement> GetByIdAsync(int id);
        Task AddAsync(Announcement announcement);
        IQueryable<Announcement> Where(Expression<Func<Announcement, bool>> expression);
        Task UpdateAsync(int id, Announcement announcement);
        Task DeleteAsync(int id);
    }
}
