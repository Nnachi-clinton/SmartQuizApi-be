using SmartQuiz.Domain.Entities;
using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IEducatorRepository : IGenericRepository<Educator>
    {
        List<Educator> GetEducatorsAsync();
        void AddEducatorAsync(Educator educator);
        void DeleteEducatorAsync(Educator educator);
        void DeleteAllEducatorsAsync(List<Educator> educators);
        public List<Educator> FindEducatorAsync(Expression<Func<Educator, bool>> condition);
        Educator GetEducatorById(string id);
        void UpdateEducatorAsync(Educator educator);
    }
}
