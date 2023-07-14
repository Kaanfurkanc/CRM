using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface IClassService
    {
        Task<IEnumerable<Class>> GetAllAsync();
        Task<Class> GetByIdAsync(int id);
        Task AddAsync(Class _class);
        Task UpdateAsync(int id,Class _class);
        Task DeleteAsync(int id);
        IQueryable<Class> Where(Expression<Func<Class,bool>> expression);
    }
}
