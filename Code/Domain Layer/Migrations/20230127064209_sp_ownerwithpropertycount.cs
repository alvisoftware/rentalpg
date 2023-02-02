using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainLayer.Migrations
{
    public partial class sp_ownerwithpropertycount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[sp_ownerwithpropertycount]
                    @FirstName varchar(50)
                AS
                BEGIN
                    SET NOCOUNT ON;
                        select own.firstname,count(prop.propertytypeid) as total from  owners as own
                        LEFT Join propertyInfos as prop on own.id= prop.ownerid
                        group  by own.id,own.firstname
                END";

            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
