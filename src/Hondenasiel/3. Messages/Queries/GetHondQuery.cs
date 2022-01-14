using Hondenasiel.Messages.Dtos;
using MediatR;
using System;

namespace Hondenasiel.Messages.Queries
{
	public class GetHondQuery : IRequest<HondReadDto>
	{
		public GetHondQuery(Guid asielId, Guid hondId)
		{
			AsielId = asielId;
			HondId = hondId;
		}

		public Guid AsielId { get; }
		public Guid HondId { get; }
	}
}