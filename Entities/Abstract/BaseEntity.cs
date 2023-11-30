using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ElektrikDagitim.Entities.Abstract
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ObjectId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? KayıtTarih { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? DuzeltmeTarihi { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? SilmeTarihi { get; set; }

        [DisplayName("Aktif")]
        public bool Aktif { get; set; } = true;


    }
}
