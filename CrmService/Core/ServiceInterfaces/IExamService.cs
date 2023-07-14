using Core.Entities;
using System.Linq.Expressions;

namespace Core.ServiceInterfaces
{
    public interface IExamService
    {
        Task<IEnumerable<Exam>> GetAllAsync();
        Task<Exam> GetByIdAsync(int id);
        IQueryable<Exam> Where(Expression<Func<Exam,bool>> expression);
        Task AddAsync(Exam exam);
        Task UpdateAsync(int id,Exam exam);
        Task DeleteAsync(int id);
    }
}
