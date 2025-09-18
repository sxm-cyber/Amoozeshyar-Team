using Amoozeshyar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amoozeshyar.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> GetByIdAsync(Guid id);

        Task<ApplicationUser?> GetByEmailAsync(string email);

        Task AddAsync(ApplicationUser user);

        Task<IEnumerable<ApplicationUser>> GetAllAsync();
    }
}
