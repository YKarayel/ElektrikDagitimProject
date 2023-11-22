using ElektrikDagıtım.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagıtım.Web.Areas.Sistem.Controllers
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
    }
}
