using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ABONE_BORCLARI",
                columns: table => new
                {
                    AboneBorcId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboneId = table.Column<int>(type: "int", nullable: false),
                    Borclar = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABONE_BORCLARI", x => x.AboneBorcId);
                });

            migrationBuilder.CreateTable(
                name: "ABONELER",
                columns: table => new
                {
                    AboneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GsmNo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    TC = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    YetkiId = table.Column<int>(type: "int", nullable: false),
                    AbnKayıtTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Durum = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ABONELER", x => x.AboneId);
                });

            migrationBuilder.CreateTable(
                name: "BUTCE_BILGILERI",
                columns: table => new
                {
                    ButceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Butce = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BUTCE_BILGILERI", x => x.ButceId);
                });

            migrationBuilder.CreateTable(
                name: "KULLANICI_YETKILERI",
                columns: table => new
                {
                    YetkiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetkiAdı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KULLANICI_YETKILERI", x => x.YetkiId);
                });

            migrationBuilder.CreateTable(
                name: "TAHSILATLAR",
                columns: table => new
                {
                    TahsilatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboneId = table.Column<int>(type: "int", nullable: false),
                    KdvOncesiTutar = table.Column<int>(type: "int", nullable: false),
                    KdvOranı = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Acıklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TahsilatTutari = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAHSILATLAR", x => x.TahsilatId);
                });

            migrationBuilder.CreateTable(
                name: "FATURALAR",
                columns: table => new
                {
                    FaturaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HizmetAdı = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaturaBedeli = table.Column<double>(type: "float", nullable: false),
                    Kdv = table.Column<int>(type: "int", nullable: false),
                    AboneId = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    TahsilatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FATURALAR", x => x.FaturaId);
                    table.ForeignKey(
                        name: "FK_FATURALAR_TAHSILATLAR_TahsilatId",
                        column: x => x.TahsilatId,
                        principalTable: "TAHSILATLAR",
                        principalColumn: "TahsilatId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FATURALAR_TahsilatId",
                table: "FATURALAR",
                column: "TahsilatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ABONE_BORCLARI");

            migrationBuilder.DropTable(
                name: "ABONELER");

            migrationBuilder.DropTable(
                name: "BUTCE_BILGILERI");

            migrationBuilder.DropTable(
                name: "FATURALAR");

            migrationBuilder.DropTable(
                name: "KULLANICI_YETKILERI");

            migrationBuilder.DropTable(
                name: "TAHSILATLAR");
        }
    }
}
