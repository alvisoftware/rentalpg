using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class RenatlDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "area",
                table: "propertyInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "badroom",
                table: "propertyInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "balcony",
                table: "propertyInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "bathroom",
                table: "propertyInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area",
                table: "propertyInfos");

            migrationBuilder.DropColumn(
                name: "badroom",
                table: "propertyInfos");

            migrationBuilder.DropColumn(
                name: "balcony",
                table: "propertyInfos");

            migrationBuilder.DropColumn(
                name: "bathroom",
                table: "propertyInfos");
        }
    }
}
