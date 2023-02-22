using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messageMasters_owners_ownerid",
                table: "messageMasters");

            migrationBuilder.DropIndex(
                name: "IX_messageMasters_ownerid",
                table: "messageMasters");

            migrationBuilder.DropColumn(
                name: "ownerid",
                table: "messageMasters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ownerid",
                table: "messageMasters",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_messageMasters_ownerid",
                table: "messageMasters",
                column: "ownerid");

            migrationBuilder.AddForeignKey(
                name: "FK_messageMasters_owners_ownerid",
                table: "messageMasters",
                column: "ownerid",
                principalTable: "owners",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
