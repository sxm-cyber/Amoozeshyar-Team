using System.Linq.Expressions;
using System.Threading.Tasks;
using Amoozeshyar.Domain.Common;

namespace Amoozeshyar.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);

        Task<List<T>> GetAllAsync();

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
        Task SaveChangesAsync();

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    }
}

