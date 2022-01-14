using Hondenasiel.Application.Commands;
using Hondenasiel.Domain.Asiel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Hondenasiel.Infrastructure.Database
{
	internal class CommandAsielRepository : ICommandAsielRepository
	{
		private readonly HondenasielDbContext _hondenasielDbContext;

		public CommandAsielRepository(HondenasielDbContext hondenasielDbContext)
		{
			_hondenasielDbContext = hondenasielDbContext;
		}

		public async Task<AsielRoot> GetAsiel(Guid asielId)
		{
			return await _hondenasielDbContext.Asielen.Include(x => x.Honden).FirstOrDefaultAsync(x => x.ID == asielId);
		}

		public async Task Save(AsielRoot asiel)
		{
			await _hondenasielDbContext.SaveChangesAsync();
		}
	}
}