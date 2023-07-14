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
    public class TeacherService : ITeacherService
    {
        private readonly IGenericRepository<Teacher> _repository;

        public TeacherService(IGenericRepository<Teacher> genericRepository)
        {
            _repository = genericRepository;
        }
        public async Task AddAsync(Teacher teacher)
        {
            await _repository.AddAsync(teacher);
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _repository.GetByIdAsync(id);
            _repository.Delete(teacher);
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            var teachers = await _repository.GetAllAsync();
            return teachers.ToList();
        }

        public Task<Teacher> GetByIdAsync(int id)
        {
            var teacher = _repository.GetByIdAsync(id);
            return teacher;
        }

        public async Task UpdateAsync(int id, Teacher teacher)
        {
            var teacherDb = await _repository.GetByIdAsync(id);
            if (teacherDb != null)
            {
                teacherDb.Surname = teacher.Surname;
                teacherDb.Name = teacher.Name;
                teacherDb.Department = teacher.Department;
                teacherDb.Email = teacher.Email;
                teacherDb.PhoneNumber = teacher.PhoneNumber;
                teacherDb.CourseId = teacher.CourseId;
                teacherDb.BirtDate = teacher.BirtDate;
                _repository.Update(teacherDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Teacher> Where(Expression<Func<Teacher, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
