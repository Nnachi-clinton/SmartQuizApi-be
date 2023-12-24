using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Persistence.Context;

namespace SmartQuiz.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SmartQuizDbContext _context;

        public UnitOfWork(SmartQuizDbContext context)
        {
            _context = context;
            EducatorRepository= new EducatorRepository(_context);
            QuizRepository = new QuizRepository(_context);
            StudentRepository = new StudentRepository(_context);

        }

        public IEducatorRepository EducatorRepository { get; private set; }

        public IQuizRepository QuizRepository { get; private set; }

        public IStudentRepository StudentRepository {  get; private set; }

        public void Dispose()
        {
           _context.Dispose();
        }

        public int SaveChangesAsync()
        {
           return _context.SaveChanges();
        }
    }
}
