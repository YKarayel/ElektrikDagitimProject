using Dal.Concrete.Sistem;
using ElektrikDagıtım.Entities.Concrete.General;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connstr = "Data Source=.;Initial Catalog=ELEKTRIK_DAGITIM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connstr);

            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {         
            //admin işlemleri
            modelBuilder.Entity<ABONE>().HasData(new ABONE
            {
                ObjectId = 1,
                AdSoyad = "admin",
                Eposta = "admin@admin.com",
                Sifre = Sifreleme_Islemleri.Sifrele("123"),
                GsmNo = "05419999999",
                TC = "12345678910",
                Aktif = true,
                KayıtTarih = DateTime.Now,
                YetkiId = 1
            });

            modelBuilder.Entity<BUTCE_BILGI>().HasData(new BUTCE_BILGI
            {
                ObjectId = 1,
                ButceName = "Ana Bütçe",
                Butce = 1000000

            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<KULLANICI_YETKI> KULLANICI_YETKILERI {  get; set; }
        public DbSet<ABONE> ABONELER { get; set; }
        public DbSet<ABONE_BORC> ABONE_BORCLARI { get; set; }
        public DbSet<TAHSILAT> TAHSILATLAR { get; set; }
        public DbSet<FATURA> FATURALAR { get; set; }
        public DbSet<BUTCE_BILGI> BUTCE_BILGILERI { get; set; }
        public DbSet<LOGGING> LOGLAR { get; set; }



    }


}
