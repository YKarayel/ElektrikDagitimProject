using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElektrikDagitim.Entities.Abstract;

namespace ElektrikDagitim.Entities.Concrete.Muhasebe
{
    public class TAHSILAT : BaseEntity
    {
        [Required]
        public int AboneId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal KdvOncesiTutar { get; set; }

        [Display(Name = "Kdv Oranı")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal KdvOranı { get; set; } = 0.20m;

        [Required]
        public string Acıklama { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TahsilatTutari { get; set; }
    }
}
