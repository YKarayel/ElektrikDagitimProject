using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.Sistem
{
    public static class Sifreleme_Islemleri
    {
        public static string Sifrele(string veri)
        {

            MD5 m = MD5.Create();
            byte[] data = System.Text.Encoding.Unicode.GetBytes(veri);
            byte[] encData = m.ComputeHash(data);
            return System.Text.Encoding.Unicode.GetString(encData);
        }
    }

}
