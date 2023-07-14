using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher> GetByIdAsync(int id);
        IQueryable<Teacher> Where(Expression<Func<Teacher, bool>> expression);
        Task AddAsync(Teacher teacher);
        Task UpdateAsync(int id, Teacher teacher);
        Task DeleteAsync(int id);
    }
}
