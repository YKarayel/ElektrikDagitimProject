using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class view_eklemeleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BUTCE_BILGILERI",
                keyColumn: "ObjectId",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ABONELER",
                columns: new[] { "ObjectId", "AdSoyad", "Aktif", "DuzeltmeTarihi", "Eposta", "GsmNo", "KayıtTarih", "Sifre", "SilmeTarihi", "TC", "YetkiId" },
                values: new object[] { 1, "admin", true, null, "admin@admin.com", "05419999999", new DateTime(2023, 11, 13, 17, 0, 45, 869, DateTimeKind.Local).AddTicks(5674), "ꉟ뺾昊ﰺꄄ헻", null, "12345678910", 1 });

            migrationBuilder.InsertData(
                table: "BUTCE_BILGILERI",
                columns: new[] { "ObjectId", "Aktif", "Butce", "ButceName", "DuzeltmeTarihi", "KayıtTarih", "SilmeTarihi" },
                values: new object[] { 1, true, 1000000L, "Ana Bütçe", null, null, null });
        }
    }
}
