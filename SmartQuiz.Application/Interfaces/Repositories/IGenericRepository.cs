using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByIdAsync(string id);
        List<T> GetAllAsync();
        List<T> FindAsync(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void SaveChangesAsync();
        bool ExistsAsync(Expression<Func<T, bool>> predicate);

    }
}
