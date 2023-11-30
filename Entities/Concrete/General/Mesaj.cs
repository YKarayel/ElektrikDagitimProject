using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagitim.Entities.Concrete.General
{
    public class Mesajlar<T> where T : class
    {
        public bool Durum { get; set; }
        public string Mesaj { get; set; }
        public string? ExMessage { get; set; }
        public T? Nesne { get; set; }
        public List<T>? Liste { get; set; }
        public string AccToken { get; set; }

    }
}
