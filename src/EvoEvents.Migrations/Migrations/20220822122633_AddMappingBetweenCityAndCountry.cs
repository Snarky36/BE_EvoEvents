using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoEvents.Migrations.Migrations
{
    public partial class AddMappingBetweenCityAndCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CityLookups_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CountryLookups_CountryId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "Addresses",
                newName: "CityCountriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CountryId",
                table: "Addresses",
                newName: "IX_Addresses_CityCountriesId");

            migrationBuilder.CreateTable(
                name: "CityCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityCountries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityCountries_CityLookups_CityId",
                        column: x => x.CityId,
                        principalTable: "CityLookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityCountries_CountryLookups_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryLookups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CityCountries",
                columns: new[] { "Id", "CityId", "CountryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 4, 2 },
                    { 5, 5, 3 },
                    { 6, 6, 3 },
                    { 7, 7, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityCountries_CityId",
                table: "CityCountries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityCountries_CountryId",
                table: "CityCountries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CityCountries_CityCountriesId",
                table: "Addresses",
                column: "CityCountriesId",
                principalTable: "CityCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_CityCountries_CityCountriesId",
                table: "Addresses");

            migrationBuilder.DropTable(
                name: "CityCountries");

            migrationBuilder.RenameColumn(
                name: "CityCountriesId",
                table: "Addresses",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_CityCountriesId",
                table: "Addresses",
                newName: "IX_Addresses_CountryId");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityId",
                table: "Addresses",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CityLookups_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "CityLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_CountryLookups_CountryId",
                table: "Addresses",
                column: "CountryId",
                principalTable: "CountryLookups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
