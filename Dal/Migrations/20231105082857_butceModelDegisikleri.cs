using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class butceModelDegisikleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ButceName",
                table: "BUTCE_BILGILERI",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "AboneId",
                keyValue: 1,
                column: "AbnKayıtTarihi",
                value: new DateTime(2023, 11, 5, 11, 28, 57, 29, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.InsertData(
                table: "BUTCE_BILGILERI",
                columns: new[] { "ButceId", "Butce", "ButceName" },
                values: new object[] { 1, 1000000L, "Ana Bütçe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BUTCE_BILGILERI",
                keyColumn: "ButceId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ButceName",
                table: "BUTCE_BILGILERI");

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "AboneId",
                keyValue: 1,
                column: "AbnKayıtTarihi",
                value: new DateTime(2023, 11, 5, 11, 23, 56, 693, DateTimeKind.Local).AddTicks(9894));
        }
    }
}
