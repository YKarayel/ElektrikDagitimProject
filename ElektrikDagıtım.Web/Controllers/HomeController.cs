using ElektrikDagıtım.Entities.Concrete.Sistem;
using ElektrikDagıtım.Entities.ViewModel;
using ElektrikDagıtım.Web.Models;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace ElektrikDagıtım.Web.Controllers
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

            m.Liste = new List<AnaSayfaYetki>()
            {
                new AnaSayfaYetki() {YetkiAdi= "Faturalar", YetkiDurum = false, modulAd = "Faturalar", modulIcon = "fa fa-calculator", modulUrl = "/Muhasebe/Muhasebe/Faturalar"},
                new AnaSayfaYetki() {YetkiAdi= "Tahsilatlar", YetkiDurum = false, modulAd = "Tahsilatlar", modulIcon = "fa fa-handshake", modulUrl = "/Muhasebe/Muhasebe/Tahsilatlar"},
                new AnaSayfaYetki() {YetkiAdi= "Profil Ayarları", YetkiDurum = false, modulAd = "Profil", modulIcon = "fa-solid fa-user-gear", modulUrl = "/Home/Profil"}
            };


            return View(m);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}