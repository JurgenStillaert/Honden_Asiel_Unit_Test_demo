using Hondenasiel.Domain.Ref;
using System;

namespace Hondenasiel.Domain.Asiel
{
	internal class Hond
	{
		public Guid ID { get; private set; }
		public string Naam { get; private set; }
		public int Leeftijd { get; private set; }
		public string Foto { get; private set; }
		public Ras Ras { get; private set; }
		public Kleur Kleur { get; private set; }
		public Geslacht Geslacht { get; private set; }
		public bool HeeftStamboom { get; private set; }
		public string Omschrijving { get; private set; }
		public AsielRoot Asiel { get; private set; }

		private Hond()
		{ }

		public static Hond MaakHond(
			Guid id,
			string naam,
			int leeftijd,
			Ras ras,
			Kleur kleur,
			Geslacht geslacht,
			bool heeftStamboom,
			string omschrijving)
		{
			if (id == null || id == Guid.Empty)
			{
				throw new ArgumentException($"'{nameof(id)}' cannot be null or empty.", nameof(id));
			}

			if (string.IsNullOrEmpty(naam))
			{
				throw new ArgumentException($"'{nameof(naam)}' cannot be null or empty.", nameof(naam));
			}

			if (ras == null)
			{
				throw new ArgumentException($"'{nameof(ras)}' cannot be null or empty.", nameof(ras));
			}

			if (kleur == null)
			{
				throw new ArgumentException($"'{nameof(kleur)}' cannot be null or empty.", nameof(kleur));
			}

			if (geslacht == null)
			{
				throw new ArgumentException($"'{nameof(geslacht)}' cannot be null or empty.", nameof(geslacht));
			}

			if (string.IsNullOrEmpty(omschrijving))
			{
				throw new ArgumentException($"'{nameof(omschrijving)}' cannot be null or empty.", nameof(omschrijving));
			}

			if (leeftijd < 0)
			{
				throw new ArgumentException($"'{nameof(leeftijd)}' cannot be null or empty.", nameof(leeftijd));
			}

			var hond = new Hond()
			{
				ID = id,
				Naam = naam,
				Leeftijd = leeftijd,
				Ras = ras,
				Kleur = kleur,
				Geslacht = geslacht,
				HeeftStamboom = heeftStamboom,
				Omschrijving = omschrijving
			};

			return hond;
		}

		public void PasFotoAan(string fotoPath)
		{
			Foto = fotoPath;
		}
	}
}