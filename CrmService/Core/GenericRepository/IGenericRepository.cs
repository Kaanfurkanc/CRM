using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.GenericRepository
{
    public  interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void Delete(T entity);
    }
}
