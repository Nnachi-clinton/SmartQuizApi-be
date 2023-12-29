using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        T GetByIdAsync(string id);
        List<T> GetAllAsync();
        List<T> GetAllAsync(Expression<Func<T, bool>> educatorId);
        List<T> FindAsync(Expression<Func<T, bool>> predicate);
        T FindA(Expression<Func<T, bool>> predicate);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        void DeleteAllAsync(List<T> entities);
        void SaveChangesAsync();
        bool ExistsAsync(Expression<Func<T, bool>> predicate);

    }
}
