using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class BaseEntity_Changed_And_Other_Entities_Changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TahsilatId",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "LOGLAR");

            migrationBuilder.DropColumn(
                name: "Tarih",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "AbnKayıtTarihi",
                table: "ABONELER");

            migrationBuilder.RenameColumn(
                name: "TahsilatId",
                table: "TAHSILATLAR",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "LogId",
                table: "LOGLAR",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "YetkiId",
                table: "KULLANICI_YETKILERI",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "TahsilatId",
                table: "FATURALAR",
                newName: "TAHSILATObjectId");

            migrationBuilder.RenameColumn(
                name: "FaturaId",
                table: "FATURALAR",
                newName: "ObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_FATURALAR_TahsilatId",
                table: "FATURALAR",
                newName: "IX_FATURALAR_TAHSILATObjectId");

            migrationBuilder.RenameColumn(
                name: "ButceId",
                table: "BUTCE_BILGILERI",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "ABONELER",
                newName: "Aktif");

            migrationBuilder.RenameColumn(
                name: "AboneId",
                table: "ABONELER",
                newName: "ObjectId");

            migrationBuilder.RenameColumn(
                name: "AboneBorcId",
                table: "ABONE_BORCLARI",
                newName: "ObjectId");

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "TAHSILATLAR",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "TAHSILATLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "TAHSILATLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "TAHSILATLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "LOGLAR",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "LOGLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "LOGLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "LOGLAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "KULLANICI_YETKILERI",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "KULLANICI_YETKILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "KULLANICI_YETKILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "KULLANICI_YETKILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "FATURALAR",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "FATURALAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "FATURALAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "FATURALAR",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "BUTCE_BILGILERI",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "BUTCE_BILGILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "BUTCE_BILGILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "BUTCE_BILGILERI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "ABONELER",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "ABONELER",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ABONELER",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Aktif",
                table: "ABONE_BORCLARI",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DuzeltmeTarihi",
                table: "ABONE_BORCLARI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "KayıtTarih",
                table: "ABONE_BORCLARI",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SilmeTarihi",
                table: "ABONE_BORCLARI",
                type: "datetime",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "ObjectId",
                keyValue: 1,
                column: "KayıtTarih",
                value: new DateTime(2023, 11, 6, 9, 38, 12, 112, DateTimeKind.Local).AddTicks(188));

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TAHSILATObjectId",
                table: "FATURALAR",
                column: "TAHSILATObjectId",
                principalTable: "TAHSILATLAR",
                principalColumn: "ObjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TAHSILATObjectId",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "TAHSILATLAR");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "LOGLAR");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "LOGLAR");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "LOGLAR");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "LOGLAR");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "KULLANICI_YETKILERI");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "KULLANICI_YETKILERI");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "KULLANICI_YETKILERI");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "KULLANICI_YETKILERI");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "FATURALAR");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "BUTCE_BILGILERI");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "BUTCE_BILGILERI");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "BUTCE_BILGILERI");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "BUTCE_BILGILERI");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ABONELER");

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "ABONE_BORCLARI");

            migrationBuilder.DropColumn(
                name: "DuzeltmeTarihi",
                table: "ABONE_BORCLARI");

            migrationBuilder.DropColumn(
                name: "KayıtTarih",
                table: "ABONE_BORCLARI");

            migrationBuilder.DropColumn(
                name: "SilmeTarihi",
                table: "ABONE_BORCLARI");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "TAHSILATLAR",
                newName: "TahsilatId");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "LOGLAR",
                newName: "LogId");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "KULLANICI_YETKILERI",
                newName: "YetkiId");

            migrationBuilder.RenameColumn(
                name: "TAHSILATObjectId",
                table: "FATURALAR",
                newName: "TahsilatId");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "FATURALAR",
                newName: "FaturaId");

            migrationBuilder.RenameIndex(
                name: "IX_FATURALAR_TAHSILATObjectId",
                table: "FATURALAR",
                newName: "IX_FATURALAR_TahsilatId");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "BUTCE_BILGILERI",
                newName: "ButceId");

            migrationBuilder.RenameColumn(
                name: "Aktif",
                table: "ABONELER",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "ABONELER",
                newName: "AboneId");

            migrationBuilder.RenameColumn(
                name: "ObjectId",
                table: "ABONE_BORCLARI",
                newName: "AboneBorcId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "TAHSILATLAR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "LOGLAR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Tarih",
                table: "FATURALAR",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "AbnKayıtTarihi",
                table: "ABONELER",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ABONELER",
                keyColumn: "AboneId",
                keyValue: 1,
                column: "AbnKayıtTarihi",
                value: new DateTime(2023, 11, 5, 11, 28, 57, 29, DateTimeKind.Local).AddTicks(7795));

            migrationBuilder.AddForeignKey(
                name: "FK_FATURALAR_TAHSILATLAR_TahsilatId",
                table: "FATURALAR",
                column: "TahsilatId",
                principalTable: "TAHSILATLAR",
                principalColumn: "TahsilatId");
        }
    }
}
