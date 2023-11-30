using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.ViewModel.Muhasebe
{
    public class V_FATURA
    {
        [Key]
        public int ObjectId { get; set; }
        public string AdSoyad { get; set; }
        public string Eposta { get; set; }
        public string GsmNo { get; set; }
        public string TC { get; set; }
        public string HizmetAdı { get; set; }
        public decimal FaturaBedeli { get; set; }
        public decimal Kdv { get; set; }
        public int AboneId { get; set; }
        public bool Odendi { get; set; }
        public int? TahsilatId { get; set; }
        public bool Aktif { get; set; }
        public DateTime? DuzeltmeTarihi { get; set; }
        public DateTime? KayıtTarih { get; set; }
        public DateTime? SilmeTarihi { get; set; }
        public decimal KdvOncesiTutar { get; set; }
        public string Donem { get; set; }


    }
}
