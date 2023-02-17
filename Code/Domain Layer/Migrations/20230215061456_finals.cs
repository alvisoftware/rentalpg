using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class finals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_propertyInfos_countries_country",
                table: "propertyInfos");

            migrationBuilder.DropIndex(
                name: "IX_propertyInfos_country",
                table: "propertyInfos");

            migrationBuilder.DropColumn(
                name: "country",
                table: "propertyInfos");

            migrationBuilder.CreateIndex(
                name: "IX_propertyInfos_countryid",
                table: "propertyInfos",
                column: "countryid");

            migrationBuilder.AddForeignKey(
                name: "FK_propertyInfos_countries_countryid",
                table: "propertyInfos",
                column: "countryid",
                principalTable: "countries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_propertyInfos_countries_countryid",
                table: "propertyInfos");

            migrationBuilder.DropIndex(
                name: "IX_propertyInfos_countryid",
                table: "propertyInfos");

            migrationBuilder.AddColumn<long>(
                name: "country",
                table: "propertyInfos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_propertyInfos_country",
                table: "propertyInfos",
                column: "country");

            migrationBuilder.AddForeignKey(
                name: "FK_propertyInfos_countries_country",
                table: "propertyInfos",
                column: "country",
                principalTable: "countries",
                principalColumn: "id");
        }
    }
}
