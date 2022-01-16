using Hondenasiel.Domain.Ref;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hondenasiel.Domain.Asiel
{
	public class AsielRoot
	{
		public Guid ID { get; private set; }
		public string Naam { get; private set; }
		public Adres Adres { get; private set; }
		public string Eigenaar { get; private set; }
		public List<Hond> Honden { get; private set; }

		public void RegistreerHond(
			Guid hondId,
			string hondNaam,
			int leeftijd,
			Ras ras,
			Kleur kleur,
			Geslacht geslacht,
			bool heeftStamboom,
			string omschrijving
			)
		{
			var hond = Hond.MaakHond(
				hondId,
				hondNaam,
				leeftijd,
				ras,
				kleur,
				geslacht,
				heeftStamboom,
				omschrijving
				);

			Honden.Add(hond);
		}

		public void LaadHondFotoOp(Guid hondId, string fotoPath)
		{
			var hond = Honden.First(x => x.ID == hondId);
			hond.PasFotoAan(fotoPath);
		}
	}
}