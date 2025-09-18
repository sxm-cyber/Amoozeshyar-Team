using System;
using Microsoft.AspNetCore.Http;

namespace Amoozeshyar.Application.Interfaces
{
	public interface IFileStorage
	{
        Task<string> SaveFileAsync(IFormFile file, string folder);
    }
}

