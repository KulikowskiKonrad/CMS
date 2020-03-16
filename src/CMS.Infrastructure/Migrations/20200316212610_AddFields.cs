using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CMS.Infrastructure.Migrations
{
    public partial class AddFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Cowsheds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    NumberOfPlaces = table.Column<short>(nullable: false),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    DateOfBuild = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cowsheds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cows",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    EarningNumber = table.Column<string>(maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Status = table.Column<short>(nullable: false),
                    Weight = table.Column<double>(nullable: true),
                    SoldPrice = table.Column<double>(nullable: true),
                    BoughtPrice = table.Column<double>(nullable: true),
                    DateOfSold = table.Column<DateTime>(nullable: true),
                    DateOfDeath = table.Column<DateTime>(nullable: true),
                    Type = table.Column<short>(nullable: false),
                    PassportNumber = table.Column<string>(maxLength: 25, nullable: false),
                    PseudoName = table.Column<string>(maxLength: 20, nullable: true),
                    InPregnant = table.Column<bool>(nullable: false),
                    Gender = table.Column<short>(nullable: false),
                    CowshedId = table.Column<long>(nullable: false),
                    MotherId = table.Column<long>(nullable: true),
                    FatherId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cows_Cowsheds_CowshedId",
                        column: x => x.CowshedId,
                        principalSchema: "dbo",
                        principalTable: "Cowsheds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cows_Cows_FatherId",
                        column: x => x.FatherId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cows_Cows_MotherId",
                        column: x => x.MotherId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cure = table.Column<string>(nullable: true),
                    SuggestedExpiriedDate = table.Column<DateTime>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    Stop = table.Column<DateTime>(nullable: false),
                    CowId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseases_Cows_CowId",
                        column: x => x.CowId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inseminations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ByDoctor = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    CowType = table.Column<short>(nullable: true),
                    MotherId = table.Column<long>(nullable: false),
                    FatherId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inseminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inseminations_Cows_FatherId",
                        column: x => x.FatherId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inseminations_Cows_MotherId",
                        column: x => x.MotherId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Milkings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    AdditionTime = table.Column<DateTime>(nullable: true),
                    Volume = table.Column<short>(nullable: false),
                    CowId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milkings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Milkings_Cows_CowId",
                        column: x => x.CowId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pregnancies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SuggestedeEndDate = table.Column<DateTime>(nullable: false),
                    CowType = table.Column<short>(nullable: false),
                    ChildId = table.Column<long>(nullable: true),
                    InseminationId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pregnancies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pregnancies_Cows_ChildId",
                        column: x => x.ChildId,
                        principalSchema: "dbo",
                        principalTable: "Cows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pregnancies_Inseminations_InseminationId",
                        column: x => x.InseminationId,
                        principalTable: "Inseminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_CowId",
                table: "Diseases",
                column: "CowId");

            migrationBuilder.CreateIndex(
                name: "IX_Inseminations_FatherId",
                table: "Inseminations",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Inseminations_MotherId",
                table: "Inseminations",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_Milkings_CowId",
                table: "Milkings",
                column: "CowId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregnancies_ChildId",
                table: "Pregnancies",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Pregnancies_InseminationId",
                table: "Pregnancies",
                column: "InseminationId",
                unique: true,
                filter: "[InseminationId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cows_CowshedId",
                schema: "dbo",
                table: "Cows",
                column: "CowshedId");

            migrationBuilder.CreateIndex(
                name: "IX_Cows_FatherId",
                schema: "dbo",
                table: "Cows",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Cows_MotherId",
                schema: "dbo",
                table: "Cows",
                column: "MotherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Milkings");

            migrationBuilder.DropTable(
                name: "Pregnancies");

            migrationBuilder.DropTable(
                name: "Inseminations");

            migrationBuilder.DropTable(
                name: "Cows",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cowsheds",
                schema: "dbo");
        }
    }
}
