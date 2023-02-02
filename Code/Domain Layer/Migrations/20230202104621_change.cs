using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ownid",
                table: "rentMasters",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rentMasters_ownid",
                table: "rentMasters",
                column: "ownid");

            migrationBuilder.AddForeignKey(
                name: "FK_rentMasters_owners_ownid",
                table: "rentMasters",
                column: "ownid",
                principalTable: "owners",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentMasters_owners_ownid",
                table: "rentMasters");

            migrationBuilder.DropIndex(
                name: "IX_rentMasters_ownid",
                table: "rentMasters");

            migrationBuilder.DropColumn(
                name: "ownid",
                table: "rentMasters");
        }
    }
}
