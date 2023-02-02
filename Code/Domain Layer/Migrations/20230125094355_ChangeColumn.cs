using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class ChangeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "owenerid",
                table: "propertyInfos",
                newName: "ownerid");

            migrationBuilder.AddColumn<long>(
                name: "ownersId",
                table: "owners",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ownersId",
                table: "owners");

            migrationBuilder.RenameColumn(
                name: "ownerid",
                table: "propertyInfos",
                newName: "owenerid");
        }
    }
}
