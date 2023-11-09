using Dal.Abstract;
using Dal.Concrete;
using Dal.Concrete.Sistem;
using Entities.Concrete.General;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagıtım.Dal.Concrete.Muhasebe
{
    public class Muhasebe_Islemleri
    {

        private readonly IEntityRepository<FATURA> _faturaRepo;
        private readonly IEntityRepository<TAHSILAT> _tahsilatRepo;
        private readonly Kullanici_Islemleri _islemler;
        private readonly AppDbContext cnt;


        public Muhasebe_Islemleri(IEntityRepository<FATURA> faturaRepo, IEntityRepository<TAHSILAT> tahsilatRepo, Kullanici_Islemleri islemler, AppDbContext cnt)
        {
            _faturaRepo = faturaRepo;
            _tahsilatRepo = tahsilatRepo;
            _islemler = islemler;
            this.cnt = cnt;
        }

        public Mesajlar<FATURA> Tum_Faturalari_Getir()
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                var faturalar = _faturaRepo.Tum_Listele().Liste;
                m.Liste = faturalar;
                m.Durum = true;
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = ex.Message;
            }
            
            return m;
        }

        public Mesajlar<FATURA> Abone_Tum_Faturalari_Getir(int aboneId)
        {
            try
            {
                var abone = _islemler.Abone_Getir(aboneId).Nesne;

                var m = _faturaRepo.Listele(x => x.AboneId == abone.ObjectId);

                if (abone.Aktif == false || abone.Eposta == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu abone numarasına ait bir kayıt mevcut değildir";
                }
                if (m.Liste == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Aboneye ait fatura mevcut değildir";
                }



                return m;
            }
            catch (Exception ex)
            {

                Mesajlar<FATURA> m = new Mesajlar<FATURA>();
                m.Durum = false;
                m.Mesaj = ex.Message;
                return m;
            }
         

        }

        public Mesajlar<FATURA> Abone_Odenmemis_Faturalari_Getir(int aboneId)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            List<FATURA> l = new List<FATURA>();

            try
            {
                var abone = _islemler.Abone_Getir(aboneId).Nesne;
                var faturalar = _faturaRepo.Listele(x => x.AboneId == abone.ObjectId).Liste;

                if (abone.Aktif == false || abone.Eposta == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu abone numarasına ait bir kayıt mevcut değildir";
                }
                if (faturalar == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Aboneye ait fatura mevcut değildir";
                }


                foreach (var fatura in faturalar)
                {
                    if (fatura.Odendi == false)
                    {
                        l.Add(fatura);

                    }
                }
                m.Liste = l;
                m.Durum = true;
            }
            catch (Exception ex)
            {

                m.Durum = false;
                m.Mesaj = ex.Message;

            }
            

            return m;


        }

        public Mesajlar<FATURA> Abone_Odenmis_Faturalari_Getir(int aboneId)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            List<FATURA> l = new List<FATURA>();
            try
            {
                var abone = _islemler.Abone_Getir(aboneId).Nesne;
                var faturalar = _faturaRepo.Listele(x => x.AboneId == abone.ObjectId).Liste;
                if (abone.Aktif == false || abone.Eposta == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu abone numarasına ait bir kayıt bulunamamıştır";
                }
                if (faturalar == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu aboneye ait fatura bulunmamıştır";
                }
                
                

                foreach (var fatura in faturalar)
                {
                    if (fatura.Odendi == true)
                    {
                        l.Add(fatura);

                    }
                }
                m.Liste = l;
                m.Durum = true;
            }
            catch (Exception ex)
            {

                m.Durum = false;
                m.ExMessage = ex.StackTrace;
            }
          

            return m;
        } 

        public Mesajlar<TAHSILAT> Abone_Tahsilatlarini_Getir(int aboneId)
        {
            try
            {
                var abone = _islemler.Abone_Getir(aboneId).Nesne;
                var m = _tahsilatRepo.Listele(x => x.AboneId == abone.ObjectId);

                if (abone.Aktif == false || abone.Eposta == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu abone numarasına ait bir kayıt bulunamamıştır";
                }
                if (m.Liste == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Aboneye ait fatura mevcut değildir";
                }


                return m;
            }
            catch (Exception ex)
            {

                Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
                m.Durum = false;
                m.ExMessage = ex.StackTrace;
                return m;
            }
            
        }

        public Mesajlar<FATURA> Donem_Faturasi_Ekle(FATURA fatura)
        {
            try
            {
                fatura.KayıtTarih = DateTime.Now;
                fatura.KdvOncesiTutar = fatura.FaturaBedeli - (fatura.FaturaBedeli * fatura.Kdv);
                var m = _faturaRepo.Ekle(fatura);
                return m;
            }
            catch (Exception)
            {

                Mesajlar<FATURA> m = new Mesajlar<FATURA>();
                m.Durum = false;
                return m;

            }
            
            
        }
        public Mesajlar<TAHSILAT> Tahsilat_Yap(int aboneId, params FATURA[] faturalar)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {


                var aboneFaturalari = _faturaRepo.Listele(x => x.AboneId == aboneId).Liste;

                if(aboneFaturalari == null)
                {
                    m.Durum = false;
                    m.Mesaj = "Bu aboneye ait fatura mevcut değildir.";
                    return m;
                }

                double tahsilatTutari = 0;
                TAHSILAT tahsilat = new TAHSILAT();
                foreach (var fatura in aboneFaturalari)
                {
                    foreach (var pFatura in faturalar)
                    {
                        var tahsilFatura = _faturaRepo.Getir(x => fatura.ObjectId == pFatura.ObjectId).Nesne;
                        tahsilFatura.DuzeltmeTarihi = DateTime.Now;
                        tahsilat.FaturaId.Add(tahsilFatura);
                        tahsilatTutari += tahsilFatura.FaturaBedeli;
                        tahsilFatura.Odendi = true;

                    }
                }
                tahsilat.TahsilatTutari = tahsilatTutari;
                tahsilat.KdvOranı = 0.20;
                tahsilat.KdvOncesiTutar = tahsilat.TahsilatTutari - (tahsilat.TahsilatTutari * tahsilat.KdvOranı);
                tahsilat.Aktif = true;
                tahsilat.KayıtTarih = DateTime.Now;
                tahsilat.AboneId = aboneId;
                tahsilat.Acıklama = "Elektrik Dağıtım fatura ödemesi";

                cnt.SaveChanges();
                m.Nesne = tahsilat;
                m.Mesaj = "Tahsilat makbuzunuz başarılı bir şekilde oluşturuldu.";
                m.Durum = true;
            }
            catch (Exception)
            {
                m.Durum = false;
                m.Mesaj = "Tahsilat başarısız";
            }


            return m;
        }


    }
}
