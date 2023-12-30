using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.Interfaces.Services
{
    public interface IEducatorServices
    {
       IEnumerable<Quiz> GetQuizzesByEducatorId(string educatorId);
       Quiz GetQuizDetails(string quizId);
       bool DeleteQuiz(string quizId);
    }
}
