using Microsoft.EntityFrameworkCore.Migrations;

namespace BTSuggestions.Web.Migrations
{
    public partial class tester2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainPointTypeEntity_PainPoints_PainPointId",
                table: "PainPointTypeEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_PainPointTypeEntity_Types_TypeId",
                table: "PainPointTypeEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PainPointTypeEntity",
                table: "PainPointTypeEntity");

            migrationBuilder.RenameTable(
                name: "PainPointTypeEntity",
                newName: "PainPointTypes");

            migrationBuilder.RenameIndex(
                name: "IX_PainPointTypeEntity_TypeId",
                table: "PainPointTypes",
                newName: "IX_PainPointTypes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PainPointTypeEntity_PainPointId",
                table: "PainPointTypes",
                newName: "IX_PainPointTypes_PainPointId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PainPointTypes",
                table: "PainPointTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PainPointTypes_PainPoints_PainPointId",
                table: "PainPointTypes",
                column: "PainPointId",
                principalTable: "PainPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PainPointTypes_Types_TypeId",
                table: "PainPointTypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PainPointTypes_PainPoints_PainPointId",
                table: "PainPointTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_PainPointTypes_Types_TypeId",
                table: "PainPointTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PainPointTypes",
                table: "PainPointTypes");

            migrationBuilder.RenameTable(
                name: "PainPointTypes",
                newName: "PainPointTypeEntity");

            migrationBuilder.RenameIndex(
                name: "IX_PainPointTypes_TypeId",
                table: "PainPointTypeEntity",
                newName: "IX_PainPointTypeEntity_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PainPointTypes_PainPointId",
                table: "PainPointTypeEntity",
                newName: "IX_PainPointTypeEntity_PainPointId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PainPointTypeEntity",
                table: "PainPointTypeEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PainPointTypeEntity_PainPoints_PainPointId",
                table: "PainPointTypeEntity",
                column: "PainPointId",
                principalTable: "PainPoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PainPointTypeEntity_Types_TypeId",
                table: "PainPointTypeEntity",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
