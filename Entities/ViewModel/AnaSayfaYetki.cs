using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.ViewModel
{
    public class AnaSayfaYetki
    {
        public string YetkiAdi { get; set; } = string.Empty;
        public bool YetkiDurum { get; set; }
        public string modulAd { get; set; } = string.Empty;
        public string modulUrl { get; set; } = string.Empty;
        public string modulIcon { get; set; } = string.Empty;

    }
}
