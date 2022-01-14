using Hondenasiel.Application.Queries;
using Hondenasiel.Messages.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hondenasiel.Infrastructure.Database
{
	internal class HondDtoRepository : IHondDtoRepository
	{
		private readonly HondenasielDbContext _hondenasielDbContext;

		public HondDtoRepository(HondenasielDbContext hondenasielDbContext)
		{
			_hondenasielDbContext = hondenasielDbContext;
		}

		public async Task<HondReadDto> GetHond(Guid hondId)
		{
			var hond = await _hondenasielDbContext
						.Honden
						.Where(x => x.ID == hondId)
						.Select(x => new HondReadDto
						{
							ID = x.ID,
							Asiel = x.Asiel.Naam,
							Geslacht = x.Geslacht.Omschrijving,
							GeslachtCode = x.Geslacht.Code,
							HeeftStamboom = x.HeeftStamboom,
							Omschrijving = x.Omschrijving,
							Naam = x.Naam,
							Kleur = x.Kleur.Omschrijving,
							KleurCode = x.Kleur.Code,
							Leeftijd = x.Leeftijd,
							Ras = x.Ras.Omschrijving,
							RasCode = x.Ras.Code,
							Foto = x.Foto
						}).FirstOrDefaultAsync();

			return hond;
		}
	}
}