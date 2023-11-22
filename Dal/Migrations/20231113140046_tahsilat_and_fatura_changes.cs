using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class tahsilat_and_fatura_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TAHSILATObjectId",
                table: "FATURALAR");

            migrationBuilder.DropIndex(
                name: "IX_FATURALAR_TAHSILATObjectId",
                table: "FATURALAR");

            migrationBuilder.RenameColumn(
                name: "TAHSILATObjectId",
                table: "FATURALAR",
                newName: "TahsilatId");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 13, 17, 0, 45, 869, DateTimeKind.Local).AddTicks(5674));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TahsilatId",
                table: "FATURALAR",
                newName: "TAHSILATObjectId");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 9, 17, 49, 56, 168, DateTimeKind.Local).AddTicks(9233));

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_TAHSILATObjectId",
                table: "FATURALAR",
                column: "TAHSILATObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TAHSILATObjectId",
                table: "FATURALAR",
                column: "TAHSILATObjectId",
                principalTable: "TAHSILATLAR",
                principalColumn: "ObjectId");
        }
    }
}
