using Microsoft.EntityFrameworkCore.Migrations;

namespace BTSuggestions.Web.Migrations
{
    public partial class Intit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PainPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PriorityLevel",
                table: "PainPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "PainPoints",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Comments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PainPoints");

            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "PainPoints");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "PainPoints");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Comments");
        }
    }
}
