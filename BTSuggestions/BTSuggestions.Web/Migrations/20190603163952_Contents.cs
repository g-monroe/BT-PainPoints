﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BTSuggestions.Web.Migrations
{
    public partial class Contents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 120, nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Firstname = table.Column<string>(maxLength: 80, nullable: false),
                    Lastname = table.Column<string>(maxLength: 80, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Privilege = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PainPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    Summary = table.Column<string>(maxLength: 1500, nullable: false),
                    Annotation = table.Column<string>(maxLength: 1500, nullable: true),
                    Status = table.Column<string>(maxLength: 100, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PriorityLevel = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    CompanyContact = table.Column<string>(nullable: true),
                    CompanyLocation = table.Column<string>(nullable: true),
                    IndustryType = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PainPoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PainPointId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CommentText = table.Column<string>(maxLength: 1500, nullable: false),
                    Status = table.Column<string>(maxLength: 80, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_PainPoints_PainPointId",
                        column: x => x.PainPointId,
                        principalTable: "PainPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PainPointTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PainPointId = table.Column<int>(nullable: false),
                    TypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainPointTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PainPointTypes_PainPoints_PainPointId",
                        column: x => x.PainPointId,
                        principalTable: "PainPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PainPointTypes_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PainPointId",
                table: "Comments",
                column: "PainPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contents_UserId",
                table: "Contents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PainPoints_UserId",
                table: "PainPoints",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PainPointTypes_PainPointId",
                table: "PainPointTypes",
                column: "PainPointId");

            migrationBuilder.CreateIndex(
                name: "IX_PainPointTypes_TypeId",
                table: "PainPointTypes",
                column: "TypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contents");

            migrationBuilder.DropTable(
                name: "PainPointTypes");

            migrationBuilder.DropTable(
                name: "PainPoints");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
