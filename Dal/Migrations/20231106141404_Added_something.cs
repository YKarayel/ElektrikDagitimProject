using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class Added_something : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "FATURALAR",
                newName: "Odendi");

            migrationBuilder.AlterColumn<double>(
                name: "TahsilatTutari",
                table: "TAHSILATLAR",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "KdvOncesiTutar",
                table: "TAHSILATLAR",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 14, 4, 3, DateTimeKind.Local).AddTicks(8444));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Odendi",
                table: "FATURALAR",
                newName: "Durum");

            migrationBuilder.AlterColumn<int>(
                name: "TahsilatTutari",
                table: "TAHSILATLAR",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "KdvOncesiTutar",
                table: "TAHSILATLAR",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 11, 59, 23, 282, DateTimeKind.Local).AddTicks(8294));
        }
    }
}
