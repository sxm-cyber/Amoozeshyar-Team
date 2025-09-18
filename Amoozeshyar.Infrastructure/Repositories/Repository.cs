using Amoozeshyar.Domain.Common;
using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Amoozeshyar.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbset;

        public Repository(ApplicationDbContext context)
<<<<<<< HEAD
        {
            _context = context;
=======
        { 
>>>>>>> 356c5dc1310c8344cf32dda79a93b5a0341a72a4
            _dbset = context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbset.AddAsync(entity);

        public async Task DeleteAsync(T entity) => _dbset.Remove(entity);

        public async Task<T> GetByIdAsync(Guid id) => await _dbset.FindAsync(id);

        public async Task<List<T>> GetAllAsync() => await _dbset.ToListAsync();

        public async Task UpdateAsync(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _dbset.Where(predicate).ToListAsync();
    }
}
