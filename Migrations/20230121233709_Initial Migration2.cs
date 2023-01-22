using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OsnTestApp.Migrations
{
    public partial class InitialMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Student");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Student",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Student",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
