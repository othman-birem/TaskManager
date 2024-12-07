using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Server.Migrations
{
    /// <inheritdoc />
    public partial class fullName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstName",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "secondName",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "fullName",
                table: "UserAccounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fullName",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "firstName",
                table: "UserAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "secondName",
                table: "UserAccounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
