using Microsoft.EntityFrameworkCore.Migrations;

namespace myfirstnetcoreapp.Migrations
{
    public partial class AddFilePathProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SomeAdd",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SomeAdd",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
