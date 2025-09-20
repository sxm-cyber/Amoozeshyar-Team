using System;
using Amoozeshyar.Application.Interfaces;

namespace Amoozeshyar.Files
{
	public class FileStorage : IFileStorage
	{
        private readonly string _rootPath;

		public FileStorage(IWebHostEnvironment env)
		{
            var webRoot = env.WebRootPath ?? Path.Combine(env.ContentRootPath, "wwwroot");
            _rootPath = Path.Combine(webRoot, "uploads");

            if (!Directory.Exists(_rootPath))
                Directory.CreateDirectory(_rootPath);
		}

        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            var folderPath = Path.Combine(_rootPath, folder);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(folderPath, fileName);

            using(var stream  = new FileStream(fullPath , FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/{folder}/{fileName}";

        }
    }
}

