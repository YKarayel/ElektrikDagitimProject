using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class tokenAndAdminSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ABONELER",
                columns: new[] { "AboneId", "AbnKayıtTarihi", "AdSoyad", "Durum", "Eposta", "GsmNo", "Sifre", "TC", "YetkiId" },
                values: new object[] { 1, new DateTime(2023, 11, 5, 11, 23, 56, 693, DateTimeKind.Local).AddTicks(9894), "admin", true, "admin@admin.com", "05419999999", "ꉟ뺾昊ﰺꄄ헻", "12345678910", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ABONELER",
                keyColumn: "AboneId",
                keyValue: 1);
        }
    }
}
