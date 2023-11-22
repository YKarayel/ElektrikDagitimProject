using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;
using System.Reflection.Metadata.Ecma335;

namespace ElektrikDagıtım.Entities.Concrete.Muhasebe
{
    public class FATURA : BaseEntity
    {
        public string HizmetAdı { get; set; } = "Elektrik Dağıtım Bedeli";
        [Required]
        public double FaturaBedeli { get; set; }
        public int? TahsilatId { get; set; }
        public string Donem { get; set; } = "2023/1";
        public double Kdv { get; set; } = 0.20;
        public double KdvOncesiTutar { get; set; }
        [Required]
        public int AboneId { get; set; }
        [Required]
        public bool Odendi { get; set; } = false;

    }
}
