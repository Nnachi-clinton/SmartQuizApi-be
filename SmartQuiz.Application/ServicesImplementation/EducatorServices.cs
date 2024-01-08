using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Application.Interfaces.Services;
using SmartQuiz.Domain.Entities;

namespace SmartQuiz.Application.ServicesImplementation
{
    public class EducatorServices: IEducatorServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public EducatorServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // Implement interface methods
        public IEnumerable<Quiz> GetQuizzesByEducatorId(string educatorId)
        {
            // Implement your business logic here
            var quizzes =  _unitOfWork.QuizRepository.GetAllQuiz(q => q.EducatorId == educatorId);
            return quizzes;
        }

        public Quiz GetQuizDetails(string quizId)
        {
            // Implement your business logic here
            var quiz = _unitOfWork.QuizRepository.GetByIdAsync(quizId);
            return quiz;
        }

        public bool DeleteQuiz(string quizId)
        {
            // Implement your business logic here
            var quiz =  _unitOfWork.QuizRepository.GetByIdAsync(quizId);

            if (quiz == null)
            {
                return false;
            }

            _unitOfWork.QuizRepository.DeleteAsync(quiz);
           _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
