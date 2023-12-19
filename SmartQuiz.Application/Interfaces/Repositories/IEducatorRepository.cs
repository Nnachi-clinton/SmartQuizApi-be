using SmartQuiz.Domain.Entities;
using System.Linq.Expressions;

namespace SmartQuiz.Application.Interfaces.Repositories
{
    public interface IEducatorRepository : IGenericRepository<Educator>
    {
        List<Educator> GetEducatorsAsync();
        void AddEducatorAsync(Educator educator);
        void DeleteEducatorAsync(Educator educator, CancellationToken cancellationToken = default);
        void DeleteAllEducatorsAsync(List<Educator> educators, CancellationToken cancellationToken = default);
        public List<Educator> FindEducatorAsync(Expression<Func<Educator, bool>> condition);
        Educator GetEducatorById(string id);
        void UpdateEducatorAsync(Educator educator);
    }
}
