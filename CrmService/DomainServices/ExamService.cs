using Core.Entities;
using Core.GenericRepository;
using Core.UnitOfWork;
using System.Linq.Expressions;
using Core.ServiceInterfaces;


namespace DomainServices
{
    public class ExamService : IExamService
    {
        private readonly IGenericRepository<Exam> _repository;

        public ExamService(IGenericRepository<Exam> examRepository)
        {
            _repository = examRepository;
        }
        public async Task AddAsync(Exam exam)
        {
            await _repository.AddAsync(exam);
        }

        public async Task DeleteAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            _repository.Delete(exam);
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            var exams = await _repository.GetAllAsync();
            return exams.ToList();
        }

        public async Task<Exam> GetByIdAsync(int id)
        {
            var exam = await _repository.GetByIdAsync(id);
            return exam;
        }

        public async Task UpdateAsync(int id, Exam exam)
        {
            var examDb = await _repository.GetByIdAsync(id);
            if (examDb != null)
            {
                examDb.ExamDescription = exam.ExamDescription;
                examDb.ExamDate = exam.ExamDate;
                examDb.ExamName = exam.ExamName;
                examDb.CourseId = exam.CourseId;
                _repository.Update(examDb);
            }
            else
            {
                throw new Exception("Can not found an entity by entered id .");
            }
        }

        public IQueryable<Exam> Where(Expression<Func<Exam, bool>> expression)
        {
            return _repository.Where(expression);
        }
    }
}
