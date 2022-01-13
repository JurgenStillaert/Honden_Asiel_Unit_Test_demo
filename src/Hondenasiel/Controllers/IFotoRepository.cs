using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Hondenasiel.Controllers
{
	public interface IFotoRepository
	{
		Task<string> SaveFoto(IFormFile foto);
	}
}