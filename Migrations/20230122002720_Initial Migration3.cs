using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OsnTestApp.Migrations
{
    public partial class InitialMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubjectCode",
                table: "StudentMark");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Parent");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Parent",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parent",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "SubjectCode",
                table: "StudentMark",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Parent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
