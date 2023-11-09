using ElektrikDagıtım.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagıtım.Web.Areas.Muhasebe.Controllers
{
    [Area("Muhasebe")]
    public class MuhasebeController : BaseController
    {
        public MuhasebeController(IHttpContextAccessor cnt, IConfiguration cfg) : base(cnt, cfg)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Faturalar()
        {
            ViewData["user"] = _baseAbone;
            ViewData["token"] = _baseToken;
            return View();
        }
    }
}
