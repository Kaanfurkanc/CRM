using Core.Entities;
using System.Linq.Expressions;

namespace Core.ServiceInterfaces
{
    public interface IGradeService
    {
        Task<IEnumerable<Grade>> GetAllAsync();
        Task<Grade> GetByIdAsync(int id);
        IQueryable<Grade> Where(Expression<Func<Grade, bool>> expression);
        Task AddAsync(Grade grade);
        Task UpdateAsync(int id,Grade grade);
        Task DeleteAsync(int id);
    }
}
