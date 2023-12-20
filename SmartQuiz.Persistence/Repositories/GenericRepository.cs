using SmartQuiz.Application.Interfaces.Repositories;
using SmartQuiz.Persistence.Context;
using System.Linq.Expressions;

namespace SmartQuiz.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SmartQuizDbContext _context;

        public GenericRepository(SmartQuizDbContext context)
        {
            _context = context;
        }

        public void AddAsync(T entity)
        {
            _context.Set<T>().AddAsync(entity);
        }

        public void DeleteAllAsync(List<T> entities)
        {
           _context.Set<T>().RemoveRange(entities);
        }

        public void DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public bool ExistsAsync(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Any(predicate);
        }

        public List<T> FindAsync(Expression<Func<T, bool>> predicate)
        {
           return _context.Set<T>().Where(predicate).ToList();
        }

        public List<T> GetAllAsync()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllAsync(Expression<Func<T, bool>> educatorId)
        {
            return _context.Set<T>().Where(educatorId).ToList();
        }

        public T GetByIdAsync(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
