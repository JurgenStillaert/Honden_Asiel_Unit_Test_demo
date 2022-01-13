using Hondenasiel.Domain.Asiel;
using System;
using System.Threading.Tasks;

namespace Hondenasiel.Application.Commands
{
	internal interface ICommandAsielRepository
	{
		Task<AsielRoot> GetAsiel(Guid asielId);
		Task Save(AsielRoot asiel);
	}
}