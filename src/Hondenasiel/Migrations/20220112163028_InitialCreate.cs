using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hondenasiel.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asielen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Straat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Huisnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Postcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres_Gemeente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eigenaar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asielen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Geslachten",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geslachten", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kleuren",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kleuren", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rassen",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rassen", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Honden",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leeftijd = table.Column<int>(type: "int", nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RasID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    KleurID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GeslachtID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HeeftStamboom = table.Column<bool>(type: "bit", nullable: false),
                    Omschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AsielID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Honden", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Honden_Asielen_AsielID",
                        column: x => x.AsielID,
                        principalTable: "Asielen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Honden_Geslachten_GeslachtID",
                        column: x => x.GeslachtID,
                        principalTable: "Geslachten",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Honden_Kleuren_KleurID",
                        column: x => x.KleurID,
                        principalTable: "Kleuren",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Honden_Rassen_RasID",
                        column: x => x.RasID,
                        principalTable: "Rassen",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Asielen",
                columns: new[] { "ID", "Eigenaar", "Naam", "Adres_Gemeente", "Adres_Huisnummer", "Adres_Postcode", "Adres_Straat" },
                values: new object[] { new Guid("de679c55-4c13-4fe7-91b4-69cbce3223a2"), "Fons De Wolf", "Asiel Zonnestraal", "Brussel", "27", "1000", "Gemeentestraat" });

            migrationBuilder.InsertData(
                table: "Geslachten",
                columns: new[] { "ID", "Code", "Omschrijving" },
                values: new object[,]
                {
                    { new Guid("83671455-8e9a-437c-ae79-9719f20ab6ce"), "M", "Reu" },
                    { new Guid("219addc2-54fb-43ba-9e8e-90f4a947b4e3"), "V", "Teef" }
                });

            migrationBuilder.InsertData(
                table: "Kleuren",
                columns: new[] { "ID", "Code", "Omschrijving" },
                values: new object[,]
                {
                    { new Guid("1c2c4bb9-9904-4972-a90a-55057da6c90e"), "ZW", "Zwart" },
                    { new Guid("aebd52e4-3539-4322-ac59-c150bdd1bfdc"), "WIT", "Wit" },
                    { new Guid("4fbb45aa-1757-4aad-a9fd-ea331ec9b7e9"), "BR", "Bruin" },
                    { new Guid("8fc42ad8-50f1-4d46-87a4-658375f1f1d2"), "ZW_WIT", "Zwart / Wit" },
                    { new Guid("f0716a85-272a-44e6-bf31-f48c00793714"), "BR_WIT", "Bruin / Wit" },
                    { new Guid("cc3b3f44-c5a2-443b-9662-c6b61d78b4fa"), "ZW_BR_WIT", "Zwart / Bruin / Wit" }
                });

            migrationBuilder.InsertData(
                table: "Rassen",
                columns: new[] { "ID", "Code", "Omschrijving" },
                values: new object[,]
                {
                    { new Guid("114b7023-57ee-4308-8ce0-28d1fe4afc47"), "LABDOO", "Labradoodle" },
                    { new Guid("e0e668c9-2177-449c-8aca-da9b07674a21"), "MECHER", "Mechelse Herder" },
                    { new Guid("90f0f2a8-7e29-441d-a5cf-bd7cb393f7dc"), "BOXER", "Boxer" },
                    { new Guid("656ed191-91cb-4409-83af-6a173fc0a959"), "BEAGLE", "Beagle" },
                    { new Guid("557d2f48-abf4-4f2d-b5a6-dae6e9edd627"), "BORCOL", "Border Collie" },
                    { new Guid("8da44df9-78d4-422d-9a8a-17f842af77af"), "GOLRET", "Golden Retriever" },
                    { new Guid("ea05349f-1c7b-4f6f-b260-437447980cae"), "LABRET", "Labrador Retriever" },
                    { new Guid("95e5c3aa-223f-46a3-8da4-9fc4131a13e5"), "MUNLAN", "Munsterlander" },
                    { new Guid("e72fc0cd-5f92-4bf5-a60d-60ffa5bf0304"), "BERSEN", "Berner Sennenhond" },
                    { new Guid("0ab165b7-0a57-47f3-9d45-0c339c10d047"), "DUIHER", "Duitse Herder" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Honden_AsielID",
                table: "Honden",
                column: "AsielID");

            migrationBuilder.CreateIndex(
                name: "IX_Honden_GeslachtID",
                table: "Honden",
                column: "GeslachtID");

            migrationBuilder.CreateIndex(
                name: "IX_Honden_KleurID",
                table: "Honden",
                column: "KleurID");

            migrationBuilder.CreateIndex(
                name: "IX_Honden_RasID",
                table: "Honden",
                column: "RasID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Honden");

            migrationBuilder.DropTable(
                name: "Asielen");

            migrationBuilder.DropTable(
                name: "Geslachten");

            migrationBuilder.DropTable(
                name: "Kleuren");

            migrationBuilder.DropTable(
                name: "Rassen");
        }
    }
}
