using Amoozeshyar.Domain.Models;

namespace Amoozeshyar.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Course> Courses { get; }

        IRepository<Enrollment> Enrollments { get; }

        Task<int> CommitAsync();
    }
}

