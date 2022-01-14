using System;

namespace Hondenasiel.Messages.Dtos
{
	public class HondDto
	{
		public string Naam { get; set; }
		public int Leeftijd { get; set; }
		public string RasCode { get; set; }
		public string KleurCode { get; set; }
		public string GeslachtCode { get; set; }
		public bool HeeftStamboom { get; set; }
		public string Omschrijving { get; set; }
	}

	public class HondDtoForCreation : HondDto
	{
	}

	public class HondReadDto : HondDto
	{
		public Guid ID { get; set; }
		public string Ras { get; set; }
		public string Kleur { get; set; }
		public string Geslacht { get; set; }
		public string Asiel { get; set; }
		public string Foto { get; set; }
	}
}