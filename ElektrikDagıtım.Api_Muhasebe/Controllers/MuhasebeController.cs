using ElektrikDagitim.Dal.Concrete.Muhasebe;
using ElektrikDagitim.Entities.Concrete.Muhasebe;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagitim.Api_Muhasebe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuhasebeController : Controller
    {

        private readonly Fatura_Islemleri _fIslemler;
        private readonly Tahsilat_Islemleri _tIslemler;

        public MuhasebeController(Fatura_Islemleri fIslemler, Tahsilat_Islemleri tIslemler)
        {
            _fIslemler = fIslemler;
            _tIslemler = tIslemler;
        }

        [HttpGet("Tum_Faturalari_Getir")]
        public IActionResult Tum_Faturalari_Getir()
        {
            var m = _fIslemler.Tum_Faturalari_Getir();
            return Json(m);

        }

        [HttpGet("Abone_Tum_Faturalari_Getir")]
        public IActionResult Abone_Tum_Faturalari_Getir([FromHeader] int aboneId)
        {
            var m = _fIslemler.Abone_Tum_Faturalari_Getir(aboneId);
            return Json(m);

        }



        [HttpGet("Abone_Odenmemis_Faturalari_Getir")]
        public IActionResult Abone_Odenmemis_Faturalari_Getir([FromHeader] int aboneId)
        {
            var m = _fIslemler.Abone_Odenmemis_Faturalari_Getir(aboneId);
            return Json(m);

        }

        [HttpGet("Abone_Odenmis_Faturalari_Getir")]
        public IActionResult Abone_Odenmis_Faturalari_Getir([FromHeader] int aboneId)
        {
            var m = _fIslemler.Abone_Odenmis_Faturalari_Getir(aboneId);
            return Json(m);

        }


        [HttpGet("Abone_Tahsilatlarini_Getir")]
        public IActionResult Abone_Tahsilatlarini_Getir([FromHeader] int aboneId)
        {
            var m = _tIslemler.Abone_Tahsilatlarini_Getir(aboneId);
            return Json(m);
        }

        [HttpPost("Donem_Faturasi_Ekle")]
        public IActionResult Donem_Faturasi_Ekle([FromBody] FATURA fatura)
        {
            var m = _fIslemler.Donem_Faturasi_Ekle(fatura);
            return Json(m);
        }

        [HttpPost("Fatura_Ode")]
        public IActionResult Fatura_Ode([FromHeader] int aboneId, [FromBody] List<FATURA> faturalar)
        {
            var m = _fIslemler.Fatura_Ode(aboneId, faturalar);
            return Json(m);
        }

        [HttpPut("Fatura_Guncelle")]
        public IActionResult Fatura_Guncelle([FromBody] FATURA fatura)
        {
            var m = _fIslemler.Fatura_Guncelle(fatura);
            return Json(m);
        }

        [HttpGet("Abone_V_Fatura_Listele")]
        public IActionResult Abone_V_Fatura_Listele([FromHeader] int aboneId)
        {
            var m = _fIslemler.Abone_V_Fatura_Listele(aboneId);
            return Json(m);
        }

        [HttpGet("V_Fatura_Getir")]
        public IActionResult V_Fatura_Getir(int faturaId)
        {
            var m = _fIslemler.V_Fatura_Getir(faturaId);
            return Json(m);
        }

        [HttpGet("Tum_V_Fatura_Getir")]
        public IActionResult Tum_V_Fatura_Listele()
        {
            var m = _fIslemler.Tum_V_Fatura_Listele();
            return Json(m);
        }


        [HttpGet("V_Tahsilat_Listele")]
        public IActionResult V_Tahsilat_Listele(int tahsilatID)
        {
            var m = _tIslemler.V_Tahsilat_Listele(tahsilatID);
            return Json(m);
        }
        [HttpPost("Fatura_Sil")]
        public IActionResult Fatura_Sil([FromHeader]int faturaId)
        {
            var m = _fIslemler.Fatura_Sil(faturaId);
            return Json(m);
        }
        [HttpGet("Fatura_KDV_Oncesi_Guncelle")]
        public IActionResult Fatura_KDV_Oncesi_Guncelle()
        {
            var m = _fIslemler.Fatura_KDV_Oncesi_Guncelle();
            return Json(m);
        }
    }
}
