using Amoozeshyar.Domain.Interfaces;
using Amoozeshyar.Domain.Models;
using Amoozeshyar.Infrastructure.Data;

namespace Amoozeshyar.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;


        public IRepository<ApplicationUser> Users { get; }
        public IRepository<Course> Courses { get; }
        public IRepository<Enrollment> Enrollments { get; }


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new Repository<ApplicationUser>(context);
            Courses = new Repository<Course>(context);
            Enrollments = new Repository<Enrollment>(context);
        }


        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

    }
}

