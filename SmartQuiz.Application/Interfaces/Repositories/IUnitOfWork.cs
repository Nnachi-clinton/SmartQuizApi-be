namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEducatorRepository EducatorRepository { get; }
        IQuizRepository QuizRepository { get; }
        IStudentRepository StudentRepository { get; }
        int SaveChangesAsync();
    }
}
