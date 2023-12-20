using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Domain.Entities;
using SmartQuiz.Persistence.Context;
using System.Linq.Expressions;

namespace SmartQuiz.Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(SmartQuizDbContext context) : base(context)
        {
        }

        public void AddStudentAsync(Student student)
        {
            AddAsync(student);
        }

        public void DeleteAllStudentsAsync(List<Student> students)
        {
            DeleteAllAsync(students);
        }

        public void DeleteStudentAsync(Student student)
        {
            DeleteAsync(student);
        }

        public List<Student> FindStudentAsync(Expression<Func<Student, bool>> condition)
        {
           return FindAsync(condition);
        }

        public Student GetStudentById(string id)
        {
           return GetByIdAsync(id);
        }

        public List<Student> GetStudentsAsync()
        {
            return GetAllAsync();
        }

        public void UpdateStudentAsync(Student student)
        {
           UpdateAsync(student);
        }
    }
}
