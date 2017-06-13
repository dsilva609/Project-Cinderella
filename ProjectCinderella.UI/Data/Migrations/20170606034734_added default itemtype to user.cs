using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCinderella.UI.Data.Migrations
{
    public partial class addeddefaultitemtypetouser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefaultItemType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultItemType",
                table: "AspNetUsers");
        }
    }
}
