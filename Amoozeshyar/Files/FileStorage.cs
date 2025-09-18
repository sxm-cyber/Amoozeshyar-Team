using System;
using Amoozeshyar.Application.Interfaces;

namespace Amoozeshyar.Files
{
	public class FileStorage : IFileStorage
	{
        private readonly IWebHostEnvironment _env;

		public FileStorage(IWebHostEnvironment env)
		{
            _env = env;
		}

        public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string folder)
        {
            var uploadsPath = Path.Combine(_env.WebRootPath, folder);

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var uniqueFileName = $"{Guid.NewGuid()} {Path.GetExtension(fileName)}";
            var filePath = Path.Combine(uploadsPath, uniqueFileName);

            using (var stream = new FileStream(filePath,FileMode.Create))
            {
                await fileStream.CopyToAsync(stream);
            }

            return $"/{folder}/{uniqueFileName}";
            
        }
    }
}

