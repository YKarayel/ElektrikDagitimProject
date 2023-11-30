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
    public class BUTCE_BILGI : BaseEntity
    {
        public string ButceName { get; set; }
        public long Butce { get; set; }
    }
}
