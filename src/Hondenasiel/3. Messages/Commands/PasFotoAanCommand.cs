using MediatR;
using System;

namespace Hondenasiel.Messages.Commands
{
	public class PasFotoAanCommand : IRequest
	{
		public PasFotoAanCommand(Guid asielId, Guid hondId, string fotoPath)
		{
			AsielId = asielId;
			HondId = hondId;
			FotoPath = fotoPath;
		}

		public Guid AsielId { get; }
		public Guid HondId { get; }
		public string FotoPath { get; }
	}
}