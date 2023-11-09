using ElektrikDagıtım.Dal.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagıtım.Api_Muhasebe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuhasebeController : Controller
    {

        private readonly Muhasebe_Islemleri _muh;

        public MuhasebeController(Muhasebe_Islemleri muh)
        {
            _muh = muh;
        }


        [HttpGet("Tum_Faturalari_Getir")]
        public IActionResult Tum_Faturalari_Getir()
        {
           var m =  _muh.Tum_Faturalari_Getir();
            return Json(m);

        }

        [HttpGet("Abone_Tum_Faturalari_Getir")]
        public IActionResult Abone_Tum_Faturalari_Getir(int aboneId)
        {
            var m = _muh.Abone_Tum_Faturalari_Getir(aboneId);
            return Json(m);

        }



        [HttpGet("Abone_Odenmemis_Faturalari_Getir")]
        public IActionResult Abone_Odenmemis_Faturalari_Getir(int aboneId)
        {
            var m = _muh.Abone_Odenmemis_Faturalari_Getir(aboneId);
            return Json(m);

        }

        [HttpGet("Abone_Odenmis_Faturalari_Getir")]
        public IActionResult Abone_Odenmis_Faturalari_Getir(int aboneId)
        {
            var m = _muh.Abone_Odenmis_Faturalari_Getir(aboneId);
            return Json(m);

        }


        [HttpGet(" Abone_Tahsilatlarini_Getir")]
        public IActionResult Abone_Tahsilatlarini_Getir(int aboneId)
        {
            var m = _muh.Abone_Tahsilatlarini_Getir(aboneId);
            return Json(m);
        }

        [HttpPost("Donem_Faturasi_Ekle")]
        public IActionResult Donem_Faturasi_Ekle(FATURA fatura)
        {
            var m = _muh.Donem_Faturasi_Ekle(fatura);
            return Json(m);
        }

        [HttpPost("Tahsilat_Yap")]
        public IActionResult Tahsilat_Yap(int aboneId, params FATURA[] faturalar)
        {
            var m = _muh.Tahsilat_Yap(aboneId, faturalar);
            return Json(m);
        }


    }
}
