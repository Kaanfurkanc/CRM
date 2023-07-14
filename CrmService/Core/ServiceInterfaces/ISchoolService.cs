using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface ISchoolService
    {
        Task<IEnumerable<School>> GetAllAsync();
        Task<School> GetByIdAsync(int id);
        Task AddAsync(School school);
        IQueryable<School> Where(Expression<Func<School, bool>> expression);
        Task UpdateAsync(int id, School school);
        Task DeleteAsync(int id);
    }
}
