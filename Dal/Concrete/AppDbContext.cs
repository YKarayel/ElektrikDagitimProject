using ElektrikDagıtım.Entities.Concrete.General;
using Entities.Concrete.Muhasebe;
using Entities.Concrete.Sistem;
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connStr = "Data Source=.;Initial Catalog=ELEKTRIK_DAGITIM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            base.OnConfiguring(optionsBuilder);

            
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
