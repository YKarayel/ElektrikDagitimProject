using ElektrikDagitim.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.Concrete.General
{
    public class LOGGING : BaseEntity
    {
        [Column(TypeName = "varchar(MAX)")]
        [MaxLength]
        public string Message { get; set; }
    }
}
