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
    [Migration("20231130131507_decimal_fatura_tahsilat")]
    partial class decimal_fatura_tahsilat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.General.LOGGING", b =>
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

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Muhasebe.BUTCE_BILGI", b =>
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
                });

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Muhasebe.FATURA", b =>
                {
                    b.Property<int>("ObjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Donem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<decimal>("FaturaBedeli")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("HizmetAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Kdv")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KdvOncesiTutar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<bool>("Odendi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<int?>("TahsilatId")
                        .HasColumnType("int");

                    b.HasKey("ObjectId");

                    b.ToTable("FATURALAR");
                });

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Muhasebe.TAHSILAT", b =>
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

                    b.Property<decimal>("KdvOncesiTutar")
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("KdvOranı")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime");

                    b.Property<decimal>("TahsilatTutari")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("ObjectId");

                    b.ToTable("TAHSILATLAR");
                });

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Sistem.ABONE", b =>
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
                });

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Sistem.ABONE_BORC", b =>
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

            modelBuilder.Entity("ElektrikDagitim.Entities.Concrete.Sistem.KULLANICI_YETKI", b =>
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

            modelBuilder.Entity("ElektrikDagitim.Entities.ViewModel.Muhasebe.V_FATURA", b =>
                {
                    b.Property<int>("ObjectId")
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ObjectId"), 1L, 1);

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Donem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("FaturaBedeli")
                        .HasColumnType("float");

                    b.Property<string>("GsmNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HizmetAdı")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime2");

                    b.Property<double>("Kdv")
                        .HasColumnType("float");

                    b.Property<double>("KdvOncesiTutar")
                        .HasColumnType("float");

                    b.Property<bool>("Odendi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TahsilatId")
                        .HasColumnType("int");

                    b.HasKey("ObjectId");

                    b.ToView("V_FATURALAR");
                });

            modelBuilder.Entity("ElektrikDagitim.Entities.ViewModel.Muhasebe.V_TAHSILAT", b =>
                {
                    b.Property<long>("ObjectId")
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ObjectId"), 1L, 1);

                    b.Property<bool>("AboneAktif")
                        .HasColumnType("bit");

                    b.Property<int>("AboneId")
                        .HasColumnType("int");

                    b.Property<string>("Acıklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Donem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DuzeltmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("FaturaAktif")
                        .HasColumnType("bit");

                    b.Property<double>("FaturaBedeli")
                        .HasColumnType("float");

                    b.Property<double>("FaturaKDV")
                        .HasColumnType("float");

                    b.Property<double>("FaturaKdvOncesiTutar")
                        .HasColumnType("float");

                    b.Property<int>("FaturaObjectID")
                        .HasColumnType("int");

                    b.Property<string>("GsmNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("KayıtTarih")
                        .HasColumnType("datetime2");

                    b.Property<double>("KdvOncesiTutar")
                        .HasColumnType("float");

                    b.Property<double>("KdvOranı")
                        .HasColumnType("float");

                    b.Property<DateTime?>("SilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("TC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TahsilatID")
                        .HasColumnType("int");

                    b.Property<double>("TahsilatTutari")
                        .HasColumnType("float");

                    b.HasKey("ObjectId");

                    b.ToView("V_TAHSILATLAR");
                });
#pragma warning restore 612, 618
        }
    }
}
