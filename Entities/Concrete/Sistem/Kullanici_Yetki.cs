using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Sistem
{
    public class KULLANICI_YETKI : BaseEntity
    {
        [Key]
        public int YetkiId { get; set; }
        public string YetkiAdı { get; set; }
    }
}
