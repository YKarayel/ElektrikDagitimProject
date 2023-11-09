using Microsoft.AspNetCore.Mvc;

namespace ElektrikDagıtım.Web.Controllers
{
    public class AboneController : BaseController
    {
        public AboneController(IHttpContextAccessor cnt, IConfiguration cfg) : base(cnt, cfg)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
