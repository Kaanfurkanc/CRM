using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetByIdAsync(int id);
        IQueryable<Course> Where(Expression<Func<Course,bool>> expression);
        Task AddAsync(Course course);
        Task UpdateAsync(int id,Course course);
        Task DeleteAsync(int id);
    }
}
