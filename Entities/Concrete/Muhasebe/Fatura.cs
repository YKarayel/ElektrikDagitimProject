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
    public class FATURA : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FaturaId { get; set; }
        public string HizmetAdı { get; set; } = "Elektrik Dağıtım Bedeli";
        public double FaturaBedeli { get; set; }
        public int Kdv { get; set; }
        public int AboneId { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }

    }
}
