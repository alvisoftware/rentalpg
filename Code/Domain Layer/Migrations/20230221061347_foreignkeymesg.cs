using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class foreignkeymesg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_messsageDetails_messagemasterid",
                table: "messsageDetails",
                column: "messagemasterid");

            migrationBuilder.AddForeignKey(
                name: "FK_messsageDetails_messageMasters_messagemasterid",
                table: "messsageDetails",
                column: "messagemasterid",
                principalTable: "messageMasters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_messsageDetails_messageMasters_messagemasterid",
                table: "messsageDetails");

            migrationBuilder.DropIndex(
                name: "IX_messsageDetails_messagemasterid",
                table: "messsageDetails");
        }
    }
}
