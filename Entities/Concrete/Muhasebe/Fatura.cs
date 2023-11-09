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
    public class FATURA : BaseEntity
    {
        public string HizmetAdı { get; set; } = "Elektrik Dağıtım Bedeli";
        [Required]
        public double FaturaBedeli { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double Kdv { get; set; } = 0.20;
        public double KdvOncesiTutar { get; set; }
        [Required]
        public int AboneId { get; set; }
        [Required]
        public bool Odendi { get; set; } = false;

    }
}
