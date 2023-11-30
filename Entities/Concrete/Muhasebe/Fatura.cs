using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using ElektrikDagitim.Entities.Abstract;

namespace ElektrikDagitim.Entities.Concrete.Muhasebe
{
    public class FATURA : BaseEntity
    {
        public string HizmetAdı { get; set; } = "Elektrik Dağıtım Bedeli";
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal FaturaBedeli { get; set; }
        public int? TahsilatId { get; set; }
        public string Donem { get; set; } = "2023/1";

        [Column(TypeName = "decimal(18,2)")]
        public decimal Kdv { get; set; } = 0.20m;

        [Column(TypeName = "decimal(18,2)")]
        public decimal KdvOncesiTutar { get; set; }
        [Required]
        public int AboneId { get; set; }
        [Required]
        public bool Odendi { get; set; } = false;

    }
}
