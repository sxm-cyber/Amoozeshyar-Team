using System;
using System.Linq.Expressions;
using Amoozeshyar.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Amoozeshyar.Infrastructure.Repositories
{
	public class Repository<T> : IRepository<T> where T :class
	{
		//private readonly DbContext _context;
		private readonly DbSet<T> _dbset;

		public Repository(DbContext context)
		{
			//_context = context;
			_dbset = context.Set<T>();
		}

        public async Task AddAsync(T entity) => await _dbset.AddAsync(entity);

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) => await _dbset.Where(predicate).ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbset.ToListAsync();

        public async Task<T?> GetByIdAsync(Guid id) => await _dbset.FindAsync(id);

        public void Remove(T entity) => _dbset.Remove(entity); 

        public void Update(T entity) => _dbset.Update(entity);

        
       
    }
}

