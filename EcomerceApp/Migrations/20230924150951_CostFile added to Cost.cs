using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomicApp.Migrations
{
    /// <inheritdoc />
    public partial class CostFileaddedtoCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CostFileId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Costs_CostFileId",
                table: "Costs",
                column: "CostFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs",
                column: "CostFileId",
                principalTable: "CostFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_CostFileId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "CostFileId",
                table: "Costs");
        }
    }
}
