using Hondenasiel.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Threading.Tasks;

namespace Hondenasiel.InfrastructureFilesystem
{
	public class FotoRepository : IFotoRepository
	{
		private readonly IConfiguration _configuration;
		private readonly IFileSystem _fileSystem;

		public FotoRepository(IFileSystem fileSystem, IConfiguration configuration)
		{
			_fileSystem = fileSystem;
			_configuration = configuration;
		}

		public async Task<string> SaveFoto(IFormFile foto)
		{
			var fileName = Path.GetFileName(foto.FileName);
			var absoluteFileName = fileName.Replace(fileName, Guid.NewGuid().ToString());
			var extension = Path.GetExtension(fileName);
			var fullFileName = string.Concat(absoluteFileName, extension);

			var physicalPath = Path.Combine(_configuration.GetValue<string>("ImageLocation"), fullFileName);

			using (var fileStream = _fileSystem.FileStream.Create(physicalPath, FileMode.Create))
			{
				await foto.CopyToAsync(fileStream);
			}

			return fullFileName;
		}
	}
}