using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Amoozeshyar.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace Amoozeshyar.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository Users { get; } 
        public IRepository<Course> Courses { get; }
        public IRepository<Enrollment> Enrollments { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new UserRepository(context);
            Courses = new Repository<Course>(context);
            Enrollments = new Repository<Enrollment>(context);
        }

        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}

