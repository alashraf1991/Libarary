using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibararyData.Migrations
{
    public partial class AddInitialentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeLibararyBranchId",
                table: "Patrons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "libararyCardId",
                table: "Patrons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LibararyBranches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    OpenDate = table.Column<DateTime>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibararyBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibararyCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fees = table.Column<decimal>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibararyCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Director = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: true),
                    DayOfWeek = table.Column<string>(nullable: true),
                    OpenTime = table.Column<string>(nullable: true),
                    CloseTime = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchHours_LibararyBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "LibararyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "libararyAssets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    NumberOfCopies = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    ISBN = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    DeweyUndex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libararyAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_libararyAssets_LibararyBranches_LocationId",
                        column: x => x.LocationId,
                        principalTable: "LibararyBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckOuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    libararyAssetsId = table.Column<int>(nullable: false),
                    libararyCardId = table.Column<int>(nullable: true),
                    Since = table.Column<DateTime>(nullable: false),
                    Until = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckOuts_libararyAssets_libararyAssetsId",
                        column: x => x.libararyAssetsId,
                        principalTable: "libararyAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckOuts_LibararyCards_libararyCardId",
                        column: x => x.libararyCardId,
                        principalTable: "LibararyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GetCheckOutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    libararyAssetsId = table.Column<int>(nullable: false),
                    libararyCardId = table.Column<int>(nullable: false),
                    CheckedOut = table.Column<DateTime>(nullable: false),
                    CheckedIn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GetCheckOutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GetCheckOutHistories_libararyAssets_libararyAssetsId",
                        column: x => x.libararyAssetsId,
                        principalTable: "libararyAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GetCheckOutHistories_LibararyCards_libararyCardId",
                        column: x => x.libararyCardId,
                        principalTable: "LibararyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LibararyAssetsId = table.Column<int>(nullable: true),
                    LibararyCardId = table.Column<int>(nullable: true),
                    HoldPlaced = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_libararyAssets_LibararyAssetsId",
                        column: x => x.LibararyAssetsId,
                        principalTable: "libararyAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_LibararyCards_LibararyCardId",
                        column: x => x.LibararyCardId,
                        principalTable: "LibararyCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_HomeLibararyBranchId",
                table: "Patrons",
                column: "HomeLibararyBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_libararyCardId",
                table: "Patrons",
                column: "libararyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_libararyAssetsId",
                table: "CheckOuts",
                column: "libararyAssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckOuts_libararyCardId",
                table: "CheckOuts",
                column: "libararyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_GetCheckOutHistories_libararyAssetsId",
                table: "GetCheckOutHistories",
                column: "libararyAssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_GetCheckOutHistories_libararyCardId",
                table: "GetCheckOutHistories",
                column: "libararyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibararyAssetsId",
                table: "Holds",
                column: "LibararyAssetsId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_LibararyCardId",
                table: "Holds",
                column: "LibararyCardId");

            migrationBuilder.CreateIndex(
                name: "IX_libararyAssets_LocationId",
                table: "libararyAssets",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibararyBranches_HomeLibararyBranchId",
                table: "Patrons",
                column: "HomeLibararyBranchId",
                principalTable: "LibararyBranches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_LibararyCards_libararyCardId",
                table: "Patrons",
                column: "libararyCardId",
                principalTable: "LibararyCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibararyBranches_HomeLibararyBranchId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_LibararyCards_libararyCardId",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckOuts");

            migrationBuilder.DropTable(
                name: "GetCheckOutHistories");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "libararyAssets");

            migrationBuilder.DropTable(
                name: "LibararyCards");

            migrationBuilder.DropTable(
                name: "LibararyBranches");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_HomeLibararyBranchId",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_libararyCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "HomeLibararyBranchId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "libararyCardId",
                table: "Patrons");
        }
    }
}
