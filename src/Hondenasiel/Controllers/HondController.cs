using Hondenasiel.Messages.Commands;
using Hondenasiel.Messages.Dtos;
using Hondenasiel.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hondenasiel.Controllers
{
	[Route("/api/Asiel/{asielId}/[controller]")]
	public class HondController : ControllerBase
	{
		private readonly IFotoRepository _fotoRepository;
		private readonly IMediator _mediator;

		public HondController(
			IMediator mediator,
			IFotoRepository fotoRepository)
		{
			_mediator = mediator;
			_fotoRepository = fotoRepository;
		}

		[HttpPost]
		public async Task<ActionResult<HondReadDto>> RegistreerHond(Guid asielId, [FromBody] HondDtoForCreation hond)
		{
			var hondId = Guid.NewGuid();
			await _mediator.Send(new RegistreerHondCommand(
								asielId,
								hondId,
								hond.Naam,
								hond.Leeftijd,
								hond.RasCode,
								hond.KleurCode,
								hond.GeslachtCode,
								hond.HeeftStamboom,
								hond.Omschrijving));

			return await GetHond(asielId, hondId);
		}

		[HttpGet]
		[Route("{hondId}")]
		public async Task<ActionResult<HondReadDto>> GetHond(Guid asielId, Guid hondId)
		{
			var hond = await _mediator.Send(new GetHondQuery(asielId, hondId));

			if (hond == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(hond);
			}
		}

		[HttpPost]
		[Route("/{hondId}/foto")]
		public async Task<ActionResult<HondReadDto>> LaadFotoOp(Guid asielId, Guid hondId, [FromForm] IFormFile file)
		{
			var physicalPath = await _fotoRepository.SaveFoto(file);

			await _mediator.Send(new PasFotoAanCommand(asielId, hondId, physicalPath));

			return await GetHond(asielId, hondId);
		}
	}
}