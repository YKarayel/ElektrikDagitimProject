using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace ElektrikDagıtım.Entities.Concrete.Muhasebe
{
    public class TAHSILAT : BaseEntity
    {
        [Required]
        public int AboneId { get; set; }
        [Required]
        public List<FATURA> FaturaId { get; set; }
        public double KdvOncesiTutar { get; set; }

        [Display(Name = "Kdv Oranı")]
        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "Doldurulması zorunludur!")]
        public double KdvOranı { get; set; } = 0.20;

        [Required]
        public string Acıklama { get; set; }
        [Required]
        public double TahsilatTutari { get; set; }
    }
}
