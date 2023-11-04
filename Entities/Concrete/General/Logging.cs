using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagıtım.Entities.Concrete.General
{
    public class LOGGING
    {
        [Key]
        public int LogId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;

        [Column(TypeName = "varchar(MAX)")]
        [MaxLength]
        public string Message { get; set; }
    }
}
