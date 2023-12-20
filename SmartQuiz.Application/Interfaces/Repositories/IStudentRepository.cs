using SmartQuiz.Domain.Entities;
using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        List<Student> GetStudentsAsync();
        void AddStudentAsync(Student student);
        void DeleteStudentAsync(Student student);
        void DeleteAllStudentsAsync(List<Student> students);
        public List<Student> FindStudentAsync(Expression<Func<Student, bool>> condition);
        Student GetStudentById(string id);
        void UpdateStudentAsync(Student student);
    }
}
