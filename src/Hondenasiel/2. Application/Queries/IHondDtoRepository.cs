using Hondenasiel.Messages.Dtos;
using System;
using System.Threading.Tasks;

namespace Hondenasiel.Application.Queries
{
	public interface IHondDtoRepository
	{
		Task<HondReadDto> GetHond(Guid hondId);
	}
}