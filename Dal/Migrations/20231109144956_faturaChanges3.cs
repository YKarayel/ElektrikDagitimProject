using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class faturaChanges3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 9, 17, 49, 56, 168, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "BUTCE_BILGILERI",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "Aktif",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 9, 17, 44, 11, 613, DateTimeKind.Local).AddTicks(4071));

            migrationBuilder.UpdateData(
                table: "BUTCE_BILGILERI",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "Aktif",
                value: false);
        }
    }
}
