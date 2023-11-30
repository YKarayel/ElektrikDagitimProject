using ElektrikDagitim.Dal.Concrete;
using ElektrikDagitim.Entities.Concrete.Sistem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElektrikDagitim.Entities.Concrete.Muhasebe;
using ElektrikDagitim.Entities.ViewModel.Muhasebe;
using ElektrikDagitim.Entities.Concrete.General;
using ElektrikDagitim.Dal.Abstract;
using ElektrikDagitim.Dal.Concrete.Sistem;

namespace ElektrikDagitim.Dal.Concrete.Muhasebe
{
    public class Fatura_Islemleri
    {

        private readonly IEntityRepository<FATURA> _faturaRepo;
        private readonly IEntityRepository<V_FATURA> _vFatura;
        private readonly IEntityRepository<TAHSILAT> _tahsilat;
        private readonly Kullanici_Islemleri _kIslemler;

        public Fatura_Islemleri(IEntityRepository<FATURA> faturaRepo, IEntityRepository<V_FATURA> vFatura, IEntityRepository<TAHSILAT> tahsilat, Kullanici_Islemleri kIslemler)
        {
            _faturaRepo = faturaRepo;
            _vFatura = vFatura;
            _tahsilat = tahsilat;
            _kIslemler = kIslemler;
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
                var abone = _kIslemler.Abone_Getir(aboneId).Nesne;

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
                var abone = _kIslemler.Abone_Getir(aboneId).Nesne;
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
                var abone = _kIslemler.Abone_Getir(aboneId).Nesne;
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
                else
                {

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



            }
            catch (Exception ex)
            {

                m.Durum = false;
                m.ExMessage = ex.StackTrace;
            }


            return m;
        }

        public Mesajlar<FATURA> Donem_Faturasi_Ekle(FATURA fatura)
        {
            try
            {
                fatura.KayıtTarih = DateTime.Now;
                fatura.KdvOncesiTutar = fatura.FaturaBedeli / (1 + fatura.Kdv);
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
        public Mesajlar<TAHSILAT> Fatura_Ode(int aboneId, List<FATURA> faturalar)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {

                decimal tahsilatTutari = 0;
                TAHSILAT tahsilat = new TAHSILAT();

                tahsilat.TahsilatTutari = 0;
                tahsilat.KdvOncesiTutar = 0;
                tahsilat.KdvOranı = 0.20m;
                tahsilat.Aktif = true;
                tahsilat.KayıtTarih = DateTime.Now;
                tahsilat.AboneId = aboneId;
                tahsilat.Acıklama = "Elektrik Dağıtım fatura ödemesi";

                _tahsilat.Ekle(tahsilat);

                foreach (var fatura in faturalar)
                {
                    {
                        tahsilatTutari += fatura.FaturaBedeli;
                        fatura.Odendi = true;
                        fatura.TahsilatId = tahsilat.ObjectId;

                        _faturaRepo.Duzelt(fatura);
                    }
                }
                tahsilat.TahsilatTutari = tahsilatTutari;
                tahsilat.KdvOncesiTutar = tahsilat.TahsilatTutari - tahsilat.TahsilatTutari * tahsilat.KdvOranı;
                _tahsilat.Duzelt(tahsilat);

            }
            catch (Exception)
            {
                m.Durum = false;
                m.Mesaj = "Tahsilat başarısız";
            }
            return m;
        }

        public Mesajlar<FATURA> Fatura_Guncelle(FATURA fatura)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                var hasData = _faturaRepo.Getir(x => x.ObjectId == fatura.ObjectId).Nesne;
                if (hasData != null)
                {
                    hasData.DuzeltmeTarihi = DateTime.Now;
                    hasData.Aktif = fatura.Aktif;
                    hasData.AboneId = fatura.AboneId;

                    if (fatura.HizmetAdı != null)
                        hasData.HizmetAdı = fatura.HizmetAdı;

                    if (fatura.Donem != null)
                        hasData.Donem = fatura.Donem;

                    if (fatura.FaturaBedeli != 0)
                    {
                        hasData.FaturaBedeli = fatura.FaturaBedeli;
                        hasData.KdvOncesiTutar = hasData.FaturaBedeli / (1 + hasData.Kdv);
                    }
                    if (fatura.Odendi != null)
                        hasData.Odendi = fatura.Odendi;

                    if (fatura.KayıtTarih != null)
                        hasData.KayıtTarih = fatura.KayıtTarih;

                    if (fatura.SilmeTarihi != null)
                        hasData.SilmeTarihi = fatura.SilmeTarihi;

                    if (fatura.TahsilatId != null)
                        hasData.TahsilatId = fatura.TahsilatId;






                    var dalM = _faturaRepo.Duzelt(hasData);
                    return dalM;
                }
                else
                {
                    m.Durum = false;
                    return m;
                }
            }
            catch (Exception ex)
            {
                m.Durum = false;
                m.Mesaj = ex.Message;
                return m;
            }

        }

        public Mesajlar<FATURA> Fatura_KDV_Oncesi_Guncelle()
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {
                var faturalar = _faturaRepo.Tum_Listele();
                if (faturalar != null)
                {
                    foreach (var item in faturalar.Liste)
                    {
                        item.KdvOncesiTutar = item.FaturaBedeli / (1 + item.Kdv);
                        _faturaRepo.Duzelt(item);
                    }

                }
                m = _faturaRepo.Tum_Listele();
                return m;
            }
            catch(Exception ex) 
            {
                m.Durum = false;
                return m;
            }
        }

        public Mesajlar<V_FATURA> Abone_V_Fatura_Listele(int aboneId)
        {
            Mesajlar<V_FATURA> m = new Mesajlar<V_FATURA>();
            try
            {
                var hasData = _vFatura.Listele(x => x.AboneId == aboneId);
                if (hasData.Liste != null)
                {
                    m.Durum = true;
                    m.Liste = hasData.Liste;
                }
                else
                    m.Durum = false;


            }
            catch (Exception ex)
            {
                m.Mesaj = ex.Message + " " + ex.StackTrace;
            }

            return m;
        }
        public Mesajlar<V_FATURA> V_Fatura_Getir(int faturaId)
        {
            Mesajlar<V_FATURA> m = new Mesajlar<V_FATURA>();
            try
            {
                var hasData = _vFatura.Getir(x => x.ObjectId == faturaId);
                if (hasData.Nesne != null)
                {
                    m.Durum = true;
                    m.Nesne = hasData.Nesne;
                }
                else
                    m.Durum = false;


            }
            catch (Exception ex)
            {
                m.Mesaj = ex.Message + " " + ex.StackTrace;
            }

            return m;
        }


        public Mesajlar<V_FATURA> Tum_V_Fatura_Listele()
        {
            Mesajlar<V_FATURA> m = new Mesajlar<V_FATURA>();


            try
            {
                var hasData = _vFatura.Tum_Listele().Liste;
                if (hasData != null)
                {
                    m.Durum = true;
                    m.Liste = hasData;
                }
                else
                    m.Durum = false;


            }
            catch (Exception ex)
            {
                m.Mesaj = ex.Message + " " + ex.StackTrace;
            }

            return m;
        }

        public Mesajlar<FATURA> Fatura_Sil(int faturaId)
        {
            Mesajlar<FATURA> m = new Mesajlar<FATURA>();
            try
            {

                var fatura = _faturaRepo.Getir(x => x.ObjectId == faturaId).Nesne;
                if (fatura != null)

                    m = _faturaRepo.Sil(fatura);
                else
                {
                    m.Durum = false;
                    m.Mesaj = "Bu faturaya ait id bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                m.Mesaj = ex.Message + " " + ex.StackTrace;
            }

            return m;
        }
    }
}
