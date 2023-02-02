using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "messageid",
                table: "subtables",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subtables_messageid",
                table: "subtables",
                column: "messageid");

            migrationBuilder.AddForeignKey(
                name: "FK_subtables_queries_messageid",
                table: "subtables",
                column: "messageid",
                principalTable: "queries",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_subtables_queries_messageid",
                table: "subtables");

            migrationBuilder.DropIndex(
                name: "IX_subtables_messageid",
                table: "subtables");

            migrationBuilder.AlterColumn<string>(
                name: "messageid",
                table: "subtables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
