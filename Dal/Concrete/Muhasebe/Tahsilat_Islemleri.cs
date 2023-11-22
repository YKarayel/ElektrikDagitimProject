using Dal.Abstract;
using Dal.Concrete.Sistem;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.ViewModel.Muhasebe;
using Entities.Concrete.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElektrikDagıtım.Dal.Concrete.Muhasebe
{
    public class Tahsilat_Islemleri
    {
        private readonly IEntityRepository<TAHSILAT> _tahsilatRepo;
        private readonly IEntityRepository<V_TAHSILAT> _vTahsilat;
        private readonly IEntityRepository<FATURA> _fatura;
        private readonly Kullanici_Islemleri _kIslemler;

        public Tahsilat_Islemleri(IEntityRepository<TAHSILAT> tahsilatRepo, IEntityRepository<V_TAHSILAT> vTahsilat, IEntityRepository<FATURA> fatura, Kullanici_Islemleri kIslemler)
        {
            _tahsilatRepo = tahsilatRepo;
            _vTahsilat = vTahsilat;
            _fatura = fatura;
            _kIslemler = kIslemler;
        }

        public Mesajlar<TAHSILAT> Abone_Tahsilatlarini_Getir(int aboneId)
        {
            try
            {
                var abone = _kIslemler.Abone_Getir(aboneId).Nesne;
                var m = _tahsilatRepo.Listele(x => x.AboneId == abone.ObjectId);

                if (abone.Aktif == false || abone.Eposta == null || abone == null)
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

        public Mesajlar<TAHSILAT> Fatura_Ode(int aboneId, List<FATURA> faturalar)
        {
            Mesajlar<TAHSILAT> m = new Mesajlar<TAHSILAT>();
            try
            {

                double tahsilatTutari = 0;
                TAHSILAT tahsilat = new TAHSILAT();

                tahsilat.TahsilatTutari = 0;
                tahsilat.KdvOncesiTutar = 0;
                tahsilat.KdvOranı = 0.20;
                tahsilat.Aktif = true;
                tahsilat.KayıtTarih = DateTime.Now;
                tahsilat.AboneId = aboneId;
                tahsilat.Acıklama = "Elektrik Dağıtım fatura ödemesi";

                _tahsilatRepo.Ekle(tahsilat);

                foreach (var fatura in faturalar)
                {
                    {
                        tahsilatTutari += fatura.FaturaBedeli;
                        fatura.Odendi = true;
                        fatura.TahsilatId = tahsilat.ObjectId;

                        _fatura.Duzelt(fatura);
                    }
                }
                tahsilat.TahsilatTutari = tahsilatTutari;
                tahsilat.KdvOncesiTutar = tahsilat.TahsilatTutari - (tahsilat.TahsilatTutari * tahsilat.KdvOranı);
                _tahsilatRepo.Duzelt(tahsilat);

            }
            catch (Exception)
            {
                m.Durum = false;
                m.Mesaj = "Tahsilat başarısız";
            }
            return m;
        }

        public Mesajlar<V_TAHSILAT> V_Tahsilat_Listele(int tahsilatID)
        {
            Mesajlar<V_TAHSILAT> m = new Mesajlar<V_TAHSILAT>();
            try
            {
                var hasData = _vTahsilat.Listele(x => x.TahsilatID == tahsilatID);
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
    }
}
