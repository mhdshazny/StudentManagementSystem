using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagementSystem.Migrations
{
    public partial class PasswordColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Tbl_Students",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Tbl_Students");
        }
    }
}
