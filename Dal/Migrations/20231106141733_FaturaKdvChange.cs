using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class FaturaKdvChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Kdv",
                table: "FATURALAR",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 17, 33, 681, DateTimeKind.Local).AddTicks(5339));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kdv",
                table: "FATURALAR",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 14, 4, 3, DateTimeKind.Local).AddTicks(8444));
        }
    }
}
