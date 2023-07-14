using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Linq.Expressions;

namespace DomainServices
{
    public class StudentService : IStudentService
    {
        private readonly IGenericRepository<Student> _repository;
        private DataContext dataContext;
        public StudentService(IGenericRepository<Student> studentRepository, DataContext dataContext)
        {
            _repository = studentRepository;
            this.dataContext = dataContext;
        }
        public async Task AddAsync(Student student)
        {
            await _repository.AddAsync(student);
        }
        public async Task DeleteAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            _repository.Delete(student);
        }

        public async Task<IEnumerable<Student>> GetAllAsync(int? page, int? pageSize)
        {
            // Server side pagination get all method . The method gets students by page and page size from database .
            var students = await dataContext.students.Skip((int)((page - 1) * pageSize)).Take((int)pageSize).ToListAsync();
            return students;
        }
        public async Task<IEnumerable<Student>> GetAllAsync(string? name, int? studentNumber)
        {
            var query = dataContext.students.AsQueryable().AsNoTracking();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(w => w.Name.ToLower().Contains(name.ToLower()));
            }
            else if (studentNumber != null)
            {
                query = query.Where(w => w.StudentNo == studentNumber);
            }
            //else if (page != null || pageSize != null)
            //{
            //    var students = await dataContext.students.Skip((int)((page - 1) * pageSize)).Take((int)pageSize).ToListAsync();
            //    return students;
            //}
            query = query.OrderBy(o => o.Id);
            return await query.ToListAsync();
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            return student;
        }

        public async Task UpdateAsync(int id, Student student)
        {
            var studentDb = await _repository.GetByIdAsync(id);
            if (studentDb != null)
            {
                studentDb.Surname = student.Surname;
                studentDb.StudentNo = student.StudentNo;
                studentDb.BirtDate = student.BirtDate;
                studentDb.Name = student.Name;
                studentDb.PhoneNumber = student.PhoneNumber;
                studentDb.ClassId = student.ClassId;
                studentDb.Email = student.Email;
                _repository.Update(studentDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Student> Where(Expression<Func<Student, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
