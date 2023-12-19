using SmartQuiz.Domain.Entities;
using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IQuizRepository : IGenericRepository<Quiz>
    {
        List<Quiz> GetQuizAsync();
        void AddQuizAsync(Quiz quiz);
        void DeleteQuizAsync(Quiz quiz, CancellationToken cancellationToken = default);
        void DeleteAllQuizAsync(List<Quiz> quiz, CancellationToken cancellationToken = default);
        public List<Quiz> FindQuizAsync(Expression<Func<Quiz, bool>> condition);
        Quiz GetQuizById(string id);
        void UpdateQuizAsync(Quiz quiz);
    }
}
