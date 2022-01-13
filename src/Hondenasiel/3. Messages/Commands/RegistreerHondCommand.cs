using MediatR;
using System;

namespace Hondenasiel.Messages.Commands
{
	public class RegistreerHondCommand : IRequest
	{
		public Guid AsielId { get; }
		public Guid HondId { get; }
		public string HondNaam { get; }
		public int Leeftijd { get; }
		public string RasCode { get; }
		public string KleurCode { get; }
		public string GeslachtCode { get; }
		public bool HeeftStamboom { get; }
		public string Omschrijving { get; }

		public RegistreerHondCommand(
			Guid asielId,
			Guid hondId,
			string hondNaam,
			int leeftijd,
			string rasCode,
			string kleurCode,
			string geslachtCode,
			bool heeftStamboom,
			string omschrijving
			)
		{
			AsielId = asielId;
			HondId = hondId;
			HondNaam = hondNaam;
			Leeftijd = leeftijd;
			RasCode = rasCode;
			KleurCode = kleurCode;
			GeslachtCode = geslachtCode;
			HeeftStamboom = heeftStamboom;
			Omschrijving = omschrijving;
		}
	}
}