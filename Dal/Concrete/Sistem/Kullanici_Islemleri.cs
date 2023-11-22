using Dal.Abstract;
using Entities.Concrete.General;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Nodes;

namespace Dal.Concrete.Sistem
{
    public class Kullanici_Islemleri
    {

        private readonly IEntityRepository<ABONE> _abnrepo;
        private readonly IEntityRepository<KULLANICI_YETKI> _yetkiRepo;
        private readonly AppDbContext _cnt;



        public Kullanici_Islemleri(IEntityRepository<ABONE> abnrepo, IEntityRepository<KULLANICI_YETKI> yetkiRepo, IEntityRepository<ABONE_BORC> aboneBorcRepo, AppDbContext cnt)
        {
            _abnrepo = abnrepo;
            _yetkiRepo = yetkiRepo;
            _cnt = cnt;
        }

        public Mesajlar<KULLANICI_YETKI> Tüm_Kullanıcı_Yetkilerini_Getir()
        {

            var m = _yetkiRepo.Tum_Listele();


            return m;

        }

        public Mesajlar<ABONE> Abone_Kontrol(string eposta, string sifre)
        {

            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            try
            {
               var abone = _abnrepo.Getir(x => x.Aktif == true && x.Eposta == eposta.ToLower() && x.Sifre == Sifreleme_Islemleri.Sifrele(sifre)).Nesne;
                if (abone == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Yetkisiz Kullanıcı";
                   
                }
                else
                {
                    m.Durum = true;
                    m.Mesaj = "Kullanıcı sisteme giriş yaptı";
                    m.Nesne = abone;
                }
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = ex.Message;
                return m;
            }
            return m;
        } 

        public Mesajlar<ABONE> Yeni_Abone(ABONE abone) 
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();

            try
            {

                var isAbone = _abnrepo.Getir(x => x.Eposta == abone.Eposta.ToLower());

                if (isAbone.Nesne!=null)
                {
                    m.Mesaj = "Bu e-postaya ait zaten bir kayıt mevcut"; 
                    m.Durum = false; 
                    return m;
                }

                abone.AdSoyad.ToLower();
                string[] words = abone.AdSoyad.Split(" ");
                string result = "";
                foreach (string word in words)
                {
                    result += char.ToUpper(word[0]) + word.Substring(1).ToLower() + " ";
                }
                abone.AdSoyad = result.TrimEnd();


                _abnrepo.Ekle(new ABONE
                {

                    AdSoyad = abone.AdSoyad,
                    Sifre = Sifreleme_Islemleri.Sifrele(abone.Sifre),
                    Eposta = abone.Eposta.ToLower(),
                    TC = abone.TC,
                    GsmNo = abone.GsmNo,
                    YetkiId = 3,
                    Aktif = true,
                    KayıtTarih = DateTime.Now
                });

                

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
        public Mesajlar<ABONE> Tum_Aboneleri_Getir()
        {
            Mesajlar<ABONE> m = new Mesajlar<ABONE>();
            var aboneList = _abnrepo.Tum_Listele().Liste;
            m.Liste = aboneList;
            m.Durum = true;

            return m;
        } 
        public Mesajlar<KULLANICI_YETKI> Abone_Kullanıcı_Yetki_Getir(int aboneId)
        {
            Mesajlar<KULLANICI_YETKI> m = new Mesajlar<KULLANICI_YETKI>();

            //m.Nesne =
            var abone = _yetkiRepo.Getir(x => x.ObjectId == aboneId).Nesne;

            if (abone == null)
            {
                m.Durum = false;
                m.Mesaj = "Abone / Kullanıcı bulunamadı";
            }
            m.Nesne = _yetkiRepo.Getir(x => x.ObjectId == abone.ObjectId).Nesne;

            return m;

        }
        public Mesajlar<ABONE> Abone_Getir(int aboneId)
        {
            var m = _abnrepo.Getir(x => x.ObjectId == aboneId);
            if(m.Nesne == null)
            {
                m.Durum = false;
                m.Mesaj = "Bu Id'ye ait bir abone mevcut değil";
                return m;
            }

            return m;
        }

    }
}