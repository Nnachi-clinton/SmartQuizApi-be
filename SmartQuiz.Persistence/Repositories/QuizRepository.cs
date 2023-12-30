using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Domain.Entities;
using SmartQuiz.Persistence.Context;
using System.Linq.Expressions;

namespace SmartQuiz.Persistence.Repositories
{
    public class QuizRepository : GenericRepository<Quiz>, IQuizRepository
    {
        public QuizRepository(SmartQuizDbContext context) : base(context) 
        {}

        public void AddQuizAsync(Quiz quiz)
        {
            AddAsync(quiz);
        }

        public void DeleteAllQuizAsync(List<Quiz> quiz)
        {
            DeleteAllAsync(quiz);
        }

        public void DeleteQuizAsync(Quiz quiz)
        {
            DeleteAsync(quiz);
        }

        public List<Quiz> FindQuizAsync(Expression<Func<Quiz, bool>> condition)
        {
            return FindAsync(condition);
        }

        public List<Quiz> GetAllQuiz(Expression<Func<Quiz, bool>> educatorid)
        {
           return FindAsync(educatorid);
        }

        public List<Quiz> GetQuizAsync()
        {
           return GetAllAsync();
        }

        public Quiz GetQuizById(string id)
        {
            return GetByIdAsync(id);
        }

        public void UpdateQuizAsync(Quiz quiz)
        {
            UpdateAsync(quiz);
        }
    }
}
