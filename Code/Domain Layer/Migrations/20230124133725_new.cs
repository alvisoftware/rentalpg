using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "propertyInfos",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "propertyInfos",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "badroom",
                table: "propertyInfos",
                newName: "bedroom");

            migrationBuilder.AddColumn<string>(
                name: "seourl",
                table: "propertyInfos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seourl",
                table: "propertyInfos");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "propertyInfos",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "propertyInfos",
                newName: "Latitude");

            migrationBuilder.RenameColumn(
                name: "bedroom",
                table: "propertyInfos",
                newName: "badroom");
        }
    }
}
