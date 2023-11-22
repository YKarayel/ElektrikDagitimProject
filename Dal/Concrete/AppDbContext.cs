using Dal.Concrete.Sistem;
using ElektrikDagıtım.Entities.Concrete.General;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using ElektrikDagıtım.Entities.ViewModel.Muhasebe;
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
            modelBuilder.Entity<V_FATURA>().ToView("V_FATURALAR");
            modelBuilder.Entity<V_TAHSILAT>().ToView("V_TAHSILATLAR");


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
