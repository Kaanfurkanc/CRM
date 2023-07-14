using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.ServiceInterfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllAsync(string? name, int? studentNumber);
        Task<IEnumerable<Student>> GetAllAsync(int? page, int? pageSize);
        Task<Student> GetByIdAsync(int id);
        IQueryable<Student> Where(Expression<Func<Student, bool>> expression);
        Task AddAsync(Student student);
        Task UpdateAsync(int id, Student student);
        Task DeleteAsync(int id);
    }
}
