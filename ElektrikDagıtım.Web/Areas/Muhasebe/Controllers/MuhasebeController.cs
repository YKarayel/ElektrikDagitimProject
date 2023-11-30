using ElektrikDagitim.Entities.Concrete.Muhasebe;
using ElektrikDagitim.Entities.Concrete.Sistem;
using ElektrikDagitim.Entities.ViewModel.Muhasebe;
using ElektrikDagitim.Web.Controllers;
using ElektrikDagitim.Entities.Concrete.General;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ElektrikDagitim.Web.Areas.Muhasebe.Controllers
{

    [Area("Muhasebe")]
    public class MuhasebeController : BaseController
    {


        public MuhasebeController(IHttpContextAccessor cnt, IConfiguration cfg) : base(cnt, cfg)
        {
        }

        public IActionResult Faturalar()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;
            return View();
        }

        public IActionResult Tahsilatlar()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;
            return View();
        }
        
        public IActionResult TumFaturalar()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");

            return View();
        }
        public IActionResult TumTahsilatlar()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");

            return View();
        }
        public IActionResult FaturaEkle()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");

            return View();
        }
        public IActionResult TahsilEdilmisFaturalar()
        {
            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userId"] = _baseAbone.ObjectId;
            ViewData["token"] = _baseToken;

            if (_baseAbone.AdSoyad != "ad")
                return RedirectToAction("home", "index");

            return View();
        }
        public IActionResult TahsilEdilmemisFaturalar()
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
