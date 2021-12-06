using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace projekt_SBD.Migrations
{
    public partial class InitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Asystenci",
                columns: table => new
                {
                    AsystentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    DrugieImie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asystenci", x => x.AsystentId);
                });

            migrationBuilder.CreateTable(
                name: "Choroby",
                columns: table => new
                {
                    ChorobaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaChoroby = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choroby", x => x.ChorobaId);
                });

            migrationBuilder.CreateTable(
                name: "Pacjenci",
                columns: table => new
                {
                    PacjentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true),
                    NumerTelefonu = table.Column<int>(nullable: false),
                    PESEL = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacjenci", x => x.PacjentId);
                });

            migrationBuilder.CreateTable(
                name: "Stomatolodzy",
                columns: table => new
                {
                    StomatologId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(nullable: true),
                    DrugieImie = table.Column<string>(nullable: true),
                    Nazwisko = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stomatolodzy", x => x.StomatologId);
                });

            migrationBuilder.CreateTable(
                name: "Uczulenia",
                columns: table => new
                {
                    UczulenieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlergenu = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uczulenia", x => x.UczulenieId);
                });

            migrationBuilder.CreateTable(
                name: "Uslugi",
                columns: table => new
                {
                    UslugaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UslugaNazwa = table.Column<string>(nullable: true),
                    Cena = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uslugi", x => x.UslugaId);
                });

            migrationBuilder.CreateTable(
                name: "AsystenciGodzinyPracy",
                columns: table => new
                {
                    ZmianaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AsystentId = table.Column<int>(nullable: false),
                    Poczatek = table.Column<DateTime>(nullable: false),
                    Koniec = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsystenciGodzinyPracy", x => x.ZmianaId);
                    table.ForeignKey(
                        name: "FK_AsystenciGodzinyPracy_Asystenci_AsystentId",
                        column: x => x.AsystentId,
                        principalTable: "Asystenci",
                        principalColumn: "AsystentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacjenciChoroby",
                columns: table => new
                {
                    PacjentId = table.Column<int>(nullable: false),
                    ChorobaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacjenciChoroby", x => new { x.PacjentId, x.ChorobaId });
                    table.ForeignKey(
                        name: "FK_PacjenciChoroby_Choroby_ChorobaId",
                        column: x => x.ChorobaId,
                        principalTable: "Choroby",
                        principalColumn: "ChorobaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacjenciChoroby_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "PacjentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StomatolodzyGodzinyPracy",
                columns: table => new
                {
                    ZmianaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StomatologId = table.Column<int>(nullable: false),
                    Poczatek = table.Column<DateTime>(nullable: false),
                    Koniec = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StomatolodzyGodzinyPracy", x => x.ZmianaId);
                    table.ForeignKey(
                        name: "FK_StomatolodzyGodzinyPracy_Stomatolodzy_StomatologId",
                        column: x => x.StomatologId,
                        principalTable: "Stomatolodzy",
                        principalColumn: "StomatologId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wizyty",
                columns: table => new
                {
                    WizytaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacjentId = table.Column<int>(nullable: false),
                    StomatologId = table.Column<int>(nullable: false),
                    AsystentId = table.Column<int>(nullable: false),
                    DataGodzina = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wizyty", x => x.WizytaId);
                    table.ForeignKey(
                        name: "FK_Wizyty_Asystenci_AsystentId",
                        column: x => x.AsystentId,
                        principalTable: "Asystenci",
                        principalColumn: "AsystentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "PacjentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wizyty_Stomatolodzy_StomatologId",
                        column: x => x.StomatologId,
                        principalTable: "Stomatolodzy",
                        principalColumn: "StomatologId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PacjenciUczulenia",
                columns: table => new
                {
                    UczulenieId = table.Column<int>(nullable: false),
                    PacjentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacjenciUczulenia", x => new { x.PacjentId, x.UczulenieId });
                    table.ForeignKey(
                        name: "FK_PacjenciUczulenia_Pacjenci_PacjentId",
                        column: x => x.PacjentId,
                        principalTable: "Pacjenci",
                        principalColumn: "PacjentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PacjenciUczulenia_Uczulenia_UczulenieId",
                        column: x => x.UczulenieId,
                        principalTable: "Uczulenia",
                        principalColumn: "UczulenieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WizytyUslugi",
                columns: table => new
                {
                    WizytaId = table.Column<int>(nullable: false),
                    UslugaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WizytyUslugi", x => new { x.WizytaId, x.UslugaId });
                    table.ForeignKey(
                        name: "FK_WizytyUslugi_Uslugi_UslugaId",
                        column: x => x.UslugaId,
                        principalTable: "Uslugi",
                        principalColumn: "UslugaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WizytyUslugi_Wizyty_WizytaId",
                        column: x => x.WizytaId,
                        principalTable: "Wizyty",
                        principalColumn: "WizytaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AsystenciGodzinyPracy_AsystentId",
                table: "AsystenciGodzinyPracy",
                column: "AsystentId");

            migrationBuilder.CreateIndex(
                name: "IX_PacjenciChoroby_ChorobaId",
                table: "PacjenciChoroby",
                column: "ChorobaId");

            migrationBuilder.CreateIndex(
                name: "IX_PacjenciUczulenia_UczulenieId",
                table: "PacjenciUczulenia",
                column: "UczulenieId");

            migrationBuilder.CreateIndex(
                name: "IX_StomatolodzyGodzinyPracy_StomatologId",
                table: "StomatolodzyGodzinyPracy",
                column: "StomatologId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_AsystentId",
                table: "Wizyty",
                column: "AsystentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_PacjentId",
                table: "Wizyty",
                column: "PacjentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wizyty_StomatologId",
                table: "Wizyty",
                column: "StomatologId");

            migrationBuilder.CreateIndex(
                name: "IX_WizytyUslugi_UslugaId",
                table: "WizytyUslugi",
                column: "UslugaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsystenciGodzinyPracy");

            migrationBuilder.DropTable(
                name: "PacjenciChoroby");

            migrationBuilder.DropTable(
                name: "PacjenciUczulenia");

            migrationBuilder.DropTable(
                name: "StomatolodzyGodzinyPracy");

            migrationBuilder.DropTable(
                name: "WizytyUslugi");

            migrationBuilder.DropTable(
                name: "Choroby");

            migrationBuilder.DropTable(
                name: "Uczulenia");

            migrationBuilder.DropTable(
                name: "Uslugi");

            migrationBuilder.DropTable(
                name: "Wizyty");

            migrationBuilder.DropTable(
                name: "Asystenci");

            migrationBuilder.DropTable(
                name: "Pacjenci");

            migrationBuilder.DropTable(
                name: "Stomatolodzy");
        }
    }
}
