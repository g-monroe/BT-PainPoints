using Microsoft.EntityFrameworkCore.Migrations;

namespace BTSuggestions.Web.Migrations
{
    public partial class tester3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Types_PainPoints_PainPointId",
                table: "Types");

            migrationBuilder.DropIndex(
                name: "IX_Types_PainPointId",
                table: "Types");

            migrationBuilder.DropColumn(
                name: "PainPointId",
                table: "Types");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PainPointId",
                table: "Types",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Types_PainPointId",
                table: "Types",
                column: "PainPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Types_PainPoints_PainPointId",
                table: "Types",
                column: "PainPointId",
                principalTable: "PainPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
