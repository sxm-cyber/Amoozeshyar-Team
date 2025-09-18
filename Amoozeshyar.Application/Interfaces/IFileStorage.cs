using System;
namespace Amoozeshyar.Application.Interfaces
{
	public interface IFileStorage
	{
        Task<string> SaveFileAsync(Stream fileStream, string fileName, string folder);
    }
}

