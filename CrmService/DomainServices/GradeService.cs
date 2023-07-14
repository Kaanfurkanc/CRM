using Core.Entities;
using Core.GenericRepository;
using Core.ServiceInterfaces;
using Core.UnitOfWork;
using System.Linq.Expressions;

namespace DomainServices
{
    public class GradeService : IGradeService
    {
        private readonly IGenericRepository<Grade> _repository;

        public GradeService(IGenericRepository<Grade> gradesRepository)
        {
            _repository = gradesRepository;
        }
        public async Task AddAsync(Grade grade)
        {
            await _repository.AddAsync(grade);
        }
        public async Task DeleteAsync(int id)
        {
            var grade = await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Grade>> GetAllAsync()
        {
            var grades = await _repository.GetAllAsync();
            return grades.ToList();
        }

        public async Task<Grade> GetByIdAsync(int id)
        {
            var grade = await _repository.GetByIdAsync(id);
            return grade;
        }

        public async Task UpdateAsync(int id, Grade grade)
        {
            var gradeDb = await _repository.GetByIdAsync(id);
            if (gradeDb != null)
            {
                gradeDb.PassedStatus = grade.PassedStatus;
                gradeDb.Point = grade.Point;
                gradeDb.ExamId = grade.ExamId;
                _repository.Update(gradeDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Grade> Where(Expression<Func<Grade, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
