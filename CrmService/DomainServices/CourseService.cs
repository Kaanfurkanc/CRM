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
    public class CourseService : ICourseService
    {
        private readonly IGenericRepository<Course> _repository;

        public CourseService(IGenericRepository<Course> courseRepository)
        {
            _repository = courseRepository;
        }
        public async Task AddAsync(Course course)
        {
            await _repository.AddAsync(course);
        }

        public async Task DeleteAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            _repository.Delete(course);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            var courses = await _repository.GetAllAsync();
            return courses.ToList();
        }

        public async Task<Course> GetByIdAsync(int id)
        {
            var course = await _repository.GetByIdAsync(id);
            return course;
        }

        public async Task UpdateAsync(int id, Course course)
        {
            var courseDb = await _repository.GetByIdAsync(id);
            if (courseDb != null)
            {
                courseDb.Name = course.Name;
                courseDb.Description = course.Description;
                courseDb.CourseCode = course.CourseCode;
                courseDb.Credit = course.Credit;
                courseDb.StudentId = course.StudentId;
                _repository.Update(courseDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Course> Where(Expression<Func<Course, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
