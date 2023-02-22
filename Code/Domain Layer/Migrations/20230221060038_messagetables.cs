using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class messagetables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "messageMasters",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyid = table.Column<long>(type: "bigint", nullable: false),
                    ownerid = table.Column<long>(type: "bigint", nullable: false),
                    tenantid = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleteddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messageMasters", x => x.id);
                    table.ForeignKey(
                        name: "FK_messageMasters_owners_ownerid",
                        column: x => x.ownerid,
                        principalTable: "owners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messageMasters_propertyInfos_propertyid",
                        column: x => x.propertyid,
                        principalTable: "propertyInfos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_messageMasters_tenants_tenantid",
                        column: x => x.tenantid,
                        principalTable: "tenants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "messsageDetails",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    messagemasterid = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    replyby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    deleteddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messsageDetails", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_messageMasters_ownerid",
                table: "messageMasters",
                column: "ownerid");

            migrationBuilder.CreateIndex(
                name: "IX_messageMasters_propertyid",
                table: "messageMasters",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "IX_messageMasters_tenantid",
                table: "messageMasters",
                column: "tenantid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "messageMasters");

            migrationBuilder.DropTable(
                name: "messsageDetails");
        }
    }
}
