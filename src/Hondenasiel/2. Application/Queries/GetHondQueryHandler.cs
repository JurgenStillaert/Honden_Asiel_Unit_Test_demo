using Hondenasiel.Application.Queries.Decorators;
using Hondenasiel.Messages.Dtos;
using Hondenasiel.Messages.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Hondenasiel.Application.Queries
{
	[AuditLog("Hello world")]
	public class GetHondQueryHandler : IRequestHandler<GetHondQuery, HondReadDto>
	{
		private readonly IHondDtoRepository _hondRepo;

		public GetHondQueryHandler(IHondDtoRepository hondRepo)
		{
			_hondRepo = hondRepo;
		}

		public async Task<HondReadDto> Handle(GetHondQuery request, CancellationToken cancellationToken)
		{
			var hond = await _hondRepo.GetHond(request.HondId);

			return hond;
		}
	}
}