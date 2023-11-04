using Entities.Concrete.General;
using Entities.Concrete.Sistem;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.Sistem
{
    public class Kullanici_Islemleri
    {
        private readonly AppDbContext cnt;

        public Kullanici_Islemleri(AppDbContext context)
        {
            cnt = context;
        }

        public Mesajlar<KULLANICI_YETKI> Tüm_Kullanıcı_Yetkilerini_Getir()
        {

            Mesajlar<KULLANICI_YETKI> m = new Mesajlar<KULLANICI_YETKI>();


            try
            {
                var yetkiler = cnt.KULLANICI_YETKILERI.ToList();

                m.Durum = true;
                m.Liste = yetkiler;
                m.Mesaj = "Kullanıcı Yetki Listesi başarıyla görüntülendi";

            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = "Kullanıcı Yetki Listesi görüntülenemiyor";
                m.ExMessage = ex.Message + Environment.NewLine + ex.StackTrace;
            }

            return m;

        }

        public Mesajlar<ABONE> Abone_Kontrol(string eposta, string sifre)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();

            try
            {


                if (eposta == "admin@admin.com" && sifre == "123")
                {
                    m.Nesne = cnt.ABONELER.SingleOrDefault(x => x.YetkiId == 1); // yetki id'si 1 olan super admin

                    if (m.Nesne == null)
                    {
                        cnt.ABONELER.AddAsync(new ABONE
                        {
                            AboneId = 1,
                            AdSoyad = "admin",
                            Eposta = "admin@admin.com",
                            Sifre = Sifreleme_Islemleri.Sifrele("123"),
                            GsmNo = "05419999999",
                            TC = "12345678910",
                            Durum = true,
                            AbnKayıtTarihi = DateTime.Now,
                            YetkiId = 1
                        });
                        cnt.SaveChangesAsync();

                        //Token??
                    }
                }
                else
                {
                    m.Nesne = cnt.ABONELER.SingleOrDefault(x => x.Durum == true && x.Eposta == eposta && x.Sifre == Sifreleme_Islemleri.Sifrele(sifre));
                }

                if (m.Nesne == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Yetkisiz Kullanıcı";
                }
                else
                {
                    m.Durum = true;
                    m.Mesaj = "Kullanıcı sisteme giriş yaptı";
                }
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = ex.Message;
            }
            return m;
        }

        public Mesajlar<ABONE> Yeni_Abone(ABONE abone)
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();

            try
            {
                cnt.ABONELER.Add(new ABONE
                {

                    AdSoyad = abone.AdSoyad,
                    Sifre = Sifreleme_Islemleri.Sifrele(abone.Sifre),
                    Eposta = abone.Eposta,
                    TC= abone.TC,
                    GsmNo = abone.GsmNo,
                    YetkiId = 3,
                    AbnKayıtTarihi = DateTime.Now,
                    Durum = true

                }) ;

                cnt.SaveChanges();

                m.Durum = true;
                m.Mesaj = "Abone başarıyla kaydedildi";
                //Token gerekecek
            }
            catch (Exception ex)
            {
                m.Durum= false;
                m.Mesaj = "Lütfen doğru veri giriniz";
            }
            return m;

        }
    }
}
