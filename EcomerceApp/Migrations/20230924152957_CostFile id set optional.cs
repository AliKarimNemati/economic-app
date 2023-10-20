using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EconomicApp.Migrations
{
    /// <inheritdoc />
    public partial class CostFileidsetoptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs");

            migrationBuilder.AlterColumn<Guid>(
                name: "CostFileId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs",
                column: "CostFileId",
                principalTable: "CostFiles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs");

            migrationBuilder.AlterColumn<Guid>(
                name: "CostFileId",
                table: "Costs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostFiles_CostFileId",
                table: "Costs",
                column: "CostFileId",
                principalTable: "CostFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
