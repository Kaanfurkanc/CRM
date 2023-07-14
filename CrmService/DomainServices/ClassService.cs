using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public class ClassService : IClassService
    {
        private readonly IGenericRepository<Class> _repository;

        public ClassService(IGenericRepository<Class> classRepository)
        {
            _repository = classRepository;
        }
        public async Task AddAsync(Class _class)
        {
            await _repository.AddAsync(_class);
        }

        public async Task DeleteAsync(int id)
        {
            var _class = await _repository.GetByIdAsync(id);
            _repository.Delete(_class);

        }

        public async Task<IEnumerable<Class>> GetAllAsync()
        {
            var classes = await _repository.GetAllAsync();
            return classes.ToList();
        }

        public async Task<Class> GetByIdAsync(int id)
        {
            var _class = await _repository.GetByIdAsync(id);
            return _class;
        }

        public async Task UpdateAsync(int id, Class _class)
        {
            var _classDb = await _repository.GetByIdAsync(id);
            if (_classDb != null)
            {
                _classDb.ClassName = _class.ClassName;
                _classDb.SchoolId = _class.SchoolId;
                _repository.Update(_classDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Class> Where(Expression<Func<Class, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
