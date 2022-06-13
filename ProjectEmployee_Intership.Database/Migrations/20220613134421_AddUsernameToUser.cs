using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectEmployee_Intership.Database.Migrations
{
    public partial class AddUsernameToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "username",
                table: "Users",
                newName: "Username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "username");
        }
    }
}
