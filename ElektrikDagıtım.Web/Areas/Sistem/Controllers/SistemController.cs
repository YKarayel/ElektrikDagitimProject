using ElektrikDagitim.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagitim.Web.Areas.Sistem.Controllers
{
    [Area("Sistem")]
    public class SistemController : BaseController
    {
        public SistemController(IHttpContextAccessor cnt, IConfiguration cfg) : base(cnt, cfg)
        {
        }


        public IActionResult AbonelikSonlandirma()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            return View();
        }

        public IActionResult TumAboneler()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");

            return View();
        }
        public IActionResult AboneSorgula()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");
            return View();
        }
    }
}
