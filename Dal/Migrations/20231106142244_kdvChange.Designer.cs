﻿// <auto-generated />
using System;
using ElektrikDagitim.Dal.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElektrikDagıtım.Dal.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231106142244_kdvChange")]
    partial class kdvChange
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElektrikDagıtım.Entities.Concrete.General.LOGGING", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(MAX)");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.HasKey("ObjectId");

                    b.ToTable("LOGLAR");
                });

            modelBuilder.Entity("Entities.Concrete.Muhasebe.BUTCE_BILGI", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<long>("Butce")
                        .HasColumnType("bigint");

                    b.Property<string>("ButceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.HasKey("ObjectId");

                    b.ToTable("BUTCE_BILGILERI");

                    b.HasData(
                        new
                        {
                            ObjectId = 1,
                            Aktif = false,
                            Butce = 1000000L,
                            ButceName = "Ana Bütçe"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Muhasebe.FATURA", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<double>("FaturaBedeli")
                        .HasColumnType("float");

                    b.Property<string>("HizmetAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Kdv")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool>("Odendi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("TAHSILATObjectId")
                        .HasColumnType("int");

                    b.HasKey("ObjectId");

                    b.HasIndex("TAHSILATObjectId");

                    b.ToTable("FATURALAR");
                });

            modelBuilder.Entity("Entities.Concrete.Muhasebe.TAHSILAT", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<string>("Acıklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<double>("KdvOncesiTutar")
                        .HasColumnType("float");

                    b.Property<decimal>("KdvOranı")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<double>("TahsilatTutari")
                        .HasColumnType("float");

                    b.HasKey("ObjectId");

                    b.ToTable("TAHSILATLAR");
                });

            modelBuilder.Entity("Entities.Concrete.Sistem.ABONE", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("GsmNo")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<int>("YetkiId")
                        .HasColumnType("int");

                    b.HasKey("ObjectId");

                    b.ToTable("ABONELER");

                    b.HasData(
                        new
                        {
                            ObjectId = 1,
                            AdSoyad = "admin",
                            Aktif = true,
                            Eposta = "admin@admin.com",
                            GsmNo = "05419999999",
                            KayıtTarih = new DateTime(2023, 11, 6, 17, 22, 44, 158, DateTimeKind.Local).AddTicks(2709),
                            Sifre = "ꉟ뺾昊ﰺꄄ헻",
                            TC = "12345678910",
                            YetkiId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Sistem.ABONE_BORC", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<double>("Borclar")
                        .HasColumnType("float");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.HasKey("ObjectId");

                    b.ToTable("ABONE_BORCLARI");
                });

            modelBuilder.Entity("Entities.Concrete.Sistem.KULLANICI_YETKI", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<string>("YetkiAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ObjectId");

                    b.ToTable("KULLANICI_YETKILERI");
                });

            modelBuilder.Entity("Entities.Concrete.Muhasebe.FATURA", b =>
                {
                    b.HasOne("Entities.Concrete.Muhasebe.TAHSILAT", null)
                        .WithMany("FaturaId")
                        .HasForeignKey("TAHSILATObjectId");
                });

            modelBuilder.Entity("Entities.Concrete.Muhasebe.TAHSILAT", b =>
                {
                    b.Navigation("FaturaId");
                });
#pragma warning restore 612, 618
        }
    }
}
