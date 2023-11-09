using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class faturaKfvOncesi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "KdvOncesiTutar",
                table: "FATURALAR",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 37, 3, 156, DateTimeKind.Local).AddTicks(7994));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KdvOncesiTutar",
                table: "FATURALAR");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 17, 22, 44, 158, DateTimeKind.Local).AddTicks(2709));
        }
    }
}
