using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTSuggestions.Web.Migrations
{
    public partial class tester2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PainPointId",
                table: "Types",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "PainPointTypeEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PainPointId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainPointTypeEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PainPointTypeEntity_PainPoints_PainPointId",
                        column: x => x.PainPointId,
                        principalTable: "PainPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainPointTypeEntity_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PainPointTypeEntity_PainPointId",
                table: "PainPointTypeEntity",
                column: "PainPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PainPointTypeEntity_TypeId",
                table: "PainPointTypeEntity",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PainPointTypeEntity");

            migrationBuilder.AlterColumn<int>(
                name: "PainPointId",
                table: "Types",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
