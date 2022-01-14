using Hondenasiel.Domain.Asiel;
using Hondenasiel.Domain.Ref;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Hondenasiel.Infrastructure.Database
{
	internal class HondenasielDbContext : DbContext
	{
		public HondenasielDbContext(DbContextOptions<HondenasielDbContext> options) : base(options)
		{
		}

		public DbSet<AsielRoot> Asielen { get; set; }
		public DbSet<Hond> Honden { get; set; }
		public DbSet<Geslacht> Geslachten { get; set; }
		public DbSet<Kleur> Kleuren { get; set; }
		public DbSet<Ras> Rassen { get; set; }

		protected override void OnModelCreating(ModelBuilder mb)
		{
			ConfigureRassen(mb.Entity<Ras>());
			ConfigureKleuren(mb.Entity<Kleur>());
			ConfigureGeslacht(mb.Entity<Geslacht>());
			ConfigureHonden(mb.Entity<Hond>());
			ConfigureAsielen(mb.Entity<AsielRoot>());
		}

		private static void ConfigureAsielen(EntityTypeBuilder<AsielRoot> mb)
		{
			mb.HasKey(x => x.ID);
			mb.Property(x => x.ID).ValueGeneratedNever();

			mb.HasData(
				new
				{
					ID = Guid.Parse("de679c55-4c13-4fe7-91b4-69cbce3223a2"),
					Naam = "Asiel Zonnestraal",
					Eigenaar = "Fons De Wolf"
				}
				);

			mb.OwnsOne(
				asiel => asiel.Adres,
				adres =>
				{
					adres.Property(a => a.Straat).HasColumnName("Adres_Straat");
					adres.Property(a => a.Huisnummer).HasColumnName("Adres_Huisnummer");
					adres.Property(a => a.Postcode).HasColumnName("Adres_Postcode");
					adres.Property(a => a.Gemeente).HasColumnName("Adres_Gemeente");
					adres.HasData(
						new
						{
							AsielRootID = Guid.Parse("de679c55-4c13-4fe7-91b4-69cbce3223a2"),
							Straat = "Gemeentestraat",
							Huisnummer = "27",
							Postcode = "1000",
							Gemeente = "Brussel"
						}
						);
				}
				);
		}

		private static void ConfigureHonden(EntityTypeBuilder<Hond> mb)
		{
			mb.HasKey(x => x.ID);
			mb.Property(x => x.ID).ValueGeneratedNever();
		}

		private static void ConfigureGeslacht(EntityTypeBuilder<Geslacht> mb)
		{
			mb.HasKey(x => x.ID);
			mb.Property(x => x.ID).ValueGeneratedNever();

			mb.HasData(
				new Geslacht
				{
					ID = Guid.NewGuid(),
					Code = "M",
					Omschrijving = "Reu"
				},
				new Geslacht
				{
					ID = Guid.NewGuid(),
					Code = "V",
					Omschrijving = "Teef"
				}
				);
		}

		private static void ConfigureKleuren(EntityTypeBuilder<Kleur> mb)
		{
			mb.HasKey(x => x.ID);
			mb.Property(x => x.ID).ValueGeneratedNever();

			mb.HasData(
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "ZW",
					Omschrijving = "Zwart"
				},
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "WIT",
					Omschrijving = "Wit"
				},
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "BR",
					Omschrijving = "Bruin"
				},
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "ZW_WIT",
					Omschrijving = "Zwart / Wit"
				},
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "BR_WIT",
					Omschrijving = "Bruin / Wit"
				},
				new Kleur
				{
					ID = Guid.NewGuid(),
					Code = "ZW_BR_WIT",
					Omschrijving = "Zwart / Bruin / Wit"
				}
				);
		}

		private static void ConfigureRassen(EntityTypeBuilder<Ras> mb)
		{
			mb.HasKey(x => x.ID);
			mb.Property(x => x.ID).ValueGeneratedNever();

			mb.HasData(
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "BORCOL",
					Omschrijving = "Border Collie"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "LABRET",
					Omschrijving = "Labrador Retriever"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "GOLRET",
					Omschrijving = "Golden Retriever"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "BERSEN",
					Omschrijving = "Berner Sennenhond"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "BEAGLE",
					Omschrijving = "Beagle"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "BOXER",
					Omschrijving = "Boxer"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "MECHER",
					Omschrijving = "Mechelse Herder"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "LABDOO",
					Omschrijving = "Labradoodle"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "MUNLAN",
					Omschrijving = "Munsterlander"
				},
				new Ras
				{
					ID = Guid.NewGuid(),
					Code = "DUIHER",
					Omschrijving = "Duitse Herder"
				}
				);
		}
	}
}