using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesSoftware.Migrations
{
    public partial class RemoveDeveloper : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Software");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Developer",
                table: "Software");
        }
    }
}
