using Amoozeshyar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoozeshyar.Domain.IRepository
{
    public interface IProfile
    {
        Task<Profile> AddAsync(Profile profile);

        Task<Profile?> GetByIdAsync(Guid id);

        Task<Profile?> GetByNameAsync(string fileName);


    }
}
