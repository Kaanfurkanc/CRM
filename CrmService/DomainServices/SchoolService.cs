using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainServices
{
    public class SchoolService : ISchoolService
    {
        private readonly IGenericRepository<School> _repository;

        public SchoolService(IGenericRepository<School> repository)
        {
            _repository = repository;
        }
        public async Task AddAsync(School school)
        {
            await _repository.AddAsync(school);
        }

        public async Task DeleteAsync(int id)
        {
            var school = await _repository.GetByIdAsync(id);
            _repository.Delete(school);
        }

        public async Task<IEnumerable<School>> GetAllAsync()
        {
            var schools = await _repository.GetAllAsync();
            return schools.ToList();
        }

        public async Task<School> GetByIdAsync(int id)
        {
            var school = await _repository.GetByIdAsync(id);
            return school;
        }


        public async Task UpdateAsync(int id, School school)
        {
            var schoolDb = await _repository.GetByIdAsync(id);
            if (schoolDb != null)
            {
                schoolDb.SchoolType = school.SchoolType;
                schoolDb.SchoolName = school.SchoolName;
                schoolDb.PhoneNumber = school.PhoneNumber;
                schoolDb.Mail = school.Mail;
                _repository.Update(schoolDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<School> Where(Expression<Func<School, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
