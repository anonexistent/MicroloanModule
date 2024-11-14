using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moneis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Sum = table.Column<float>(type: "REAL", nullable: false),
                    Time = table.Column<uint>(type: "INTEGER", nullable: false),
                    Rate = table.Column<float>(type: "REAL", nullable: false),
                    MoneyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moneis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MicroloanItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CurrentSum = table.Column<float>(type: "REAL", nullable: false),
                    GeneralDebt = table.Column<float>(type: "REAL", nullable: false),
                    RateDebt = table.Column<float>(type: "REAL", nullable: false),
                    MoneyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MicroloanItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MicroloanItem_Moneis_MoneyId",
                        column: x => x.MoneyId,
                        principalTable: "Moneis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MicroloanItem_MoneyId",
                table: "MicroloanItem",
                column: "MoneyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MicroloanItem");

            migrationBuilder.DropTable(
                name: "Moneis");
        }
    }
}
