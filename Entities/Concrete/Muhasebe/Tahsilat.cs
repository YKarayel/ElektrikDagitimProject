using Entities.Concrete.Sistem;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities.Concrete.Muhasebe
{
    public class TAHSILAT : BaseEntity
    {
        public int TahsilatId { get; set; }
        public int AboneId { get; set; }
        [Required]
        public List<FATURA> Faturalar { get; set; }
        public int KdvOncesiTutar { get; set; }

        [Display(Name = "Kdv Oranı")]
        [Column(TypeName = "decimal(18,4)")]
        [Required(ErrorMessage = "Doldurulması zorunludur!")]
        public int KdvOranı { get; set; }
        public string Acıklama { get; set; }
        public int TahsilatTutari { get; set; }
        public DateTime Tarih { get; set; }
       

    }
}
