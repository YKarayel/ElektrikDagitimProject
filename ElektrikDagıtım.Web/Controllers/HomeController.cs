using DevExpress.CodeParser;
using ElektrikDagitim.Entities.Concrete.General;
using ElektrikDagitim.Entities.Concrete.Sistem;
using ElektrikDagitim.Entities.ViewModel;
using ElektrikDagitim.Entities.ViewModel.Muhasebe;
using ElektrikDagitim.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ElektrikDagitim.Web.Controllers
{
    public class HomeController : Controller
    {
        IHttpContextAccessor _cnt;
        IConfiguration _cfg;

        public ABONE _baseAbone { get; set; }
        public string _baseToken { get; set; }


        public HomeController(IHttpContextAccessor cnt, IConfiguration cfg)
        {
            _cnt = cnt;
            _cfg = cfg;

            var login = _cnt.HttpContext.Session.GetObject<ABONE_LOGIN_RESPONSE>("login");

            if (login != null)
            {
                _baseAbone = login.Abone;
                _baseToken = login.Token;

            }
        }

        public IActionResult Index()
        {
            HttpContext.Session.Clear();


            return View();
        }

        [HttpPost(Name = "")]
        public IActionResult Session_LoginSet(string txtLogin)
        {
            var snc = JsonConvert.DeserializeObject<ABONE_LOGIN_RESPONSE>(txtLogin);

            HttpContext.Session.SetObject("login", snc);

            return Redirect("/home/anasayfa");
        }

        public IActionResult Anasayfa()
        {
            if (_baseAbone == null)
            {
                HttpContext.Session.Clear();
                return Redirect("/Home/Index");
            }

            ViewData["user"] = _baseAbone.AdSoyad;
            ViewData["userToken"] = _baseToken;

            Mesajlar<AnaSayfaYetki> m = new Mesajlar<AnaSayfaYetki>();

            if (_baseAbone.AdSoyad == "ad")
            {

                m.Liste = new List<AnaSayfaYetki>()
                {
                    new AnaSayfaYetki() { YetkiAdi = "TumFaturalar", YetkiDurum = true, modulAd = "Tüm Faturalar", modulIcon = "fa-solid fa-file-invoice", modulUrl = "/Muhasebe/Muhasebe/TumFaturalar" },
                    new AnaSayfaYetki() { YetkiAdi = "TumAboneler", YetkiDurum = true, modulAd = "Tüm Aboneler", modulIcon = "fa-solid fa-users", modulUrl = "/Sistem/Sistem/TumAboneler" },
                    new AnaSayfaYetki() { YetkiAdi = "TumTahsilatlar", YetkiDurum = true, modulAd = "Tüm Tahsilatlar", modulIcon = "fa-solid fa-file-invoice-dollar", modulUrl = "/Muhasebe/Muhasebe/TumTahsilatlar" },
                    new AnaSayfaYetki() { YetkiAdi = "AboneSorgula", YetkiDurum = true, modulAd = "Abone Sorgula", modulIcon = "fa-solid fa-plus", modulUrl = "/Sistem/Sistem/AboneSorgula" },
                    new AnaSayfaYetki() { YetkiAdi = "TahsilEdilmisFaturalar", YetkiDurum = true, modulAd = "Tahsil Edilmiş Faturalar", modulIcon = "fa-solid fa-file-circle-check", modulUrl = "/Muhasebe/Muhasebe/TahsilEdilmisFaturalar" },
                    new AnaSayfaYetki() { YetkiAdi = "TahsilEdilmemisFaturalar", YetkiDurum = true, modulAd = "Tahsil Edilmemiş Faturalar", modulIcon = "fa-solid fa-file-circle-exclamation", modulUrl = "/Muhasebe/Muhasebe/TahsilEdilmemisFaturalar" },
                };
            }
            else
            {
                m.Liste = new List<AnaSayfaYetki>()
                    {
                        new AnaSayfaYetki() { YetkiAdi = "Faturalar", YetkiDurum = false, modulAd = "Faturalar", modulIcon = "fa fa-calculator", modulUrl = "/Muhasebe/Muhasebe/Faturalar" },
                        new AnaSayfaYetki() { YetkiAdi = "Tahsilatlar", YetkiDurum = false, modulAd = "Tahsilatlar", modulIcon = "fa fa-handshake", modulUrl = "/Muhasebe/Muhasebe/Tahsilatlar" },
                        new AnaSayfaYetki() { YetkiAdi = "AbonelikSonlandırma", YetkiDurum = false, modulAd = "Abonelik Sonlandırma", modulIcon = "fa-solid fa-square-arrow-up-right", modulUrl = "/Sistem/Sistem/AbonelikSonlandirma" },
                    };
            }

            return View(m);
        }

        public IActionResult Register()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}