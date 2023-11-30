using ElektrikDagitim.Entities.Concrete.Sistem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ElektrikDagitim.Web.Controllers
{
    public class BaseController : Controller
    {

        IHttpContextAccessor _cnt;
        IConfiguration _cfg;

       
        public ABONE _baseAbone { get; set; }
        public string _baseToken { get; set; }
        public string _WebUrl { get; }

        public BaseController(IHttpContextAccessor cnt, IConfiguration cfg)
        {
            _cnt = cnt;
            _cfg = cfg;
            if (cnt == null || cnt.HttpContext == null || cnt.HttpContext.Session == null)
            {
                RedirectToAction("/Home/Index");


            }

            var login = _cnt.HttpContext.Session.GetObject<ABONE_LOGIN_RESPONSE>("login");

            if (login != null)
            {
                _baseAbone = login.Abone;
                _baseToken = login.Token;
            }

            _WebUrl = _cfg.GetValue<string>("WebUrl");

            if (_baseAbone == null)
            {
                RedirectToAction("/Home/Index");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var login = _cnt.HttpContext.Session.GetObject<ABONE_LOGIN_RESPONSE>("login");

            if (_cnt.HttpContext.Session.IsAvailable == false)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }

            if (login == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
            else
            {
                Controller c = context.Controller as Controller;

                if (_baseAbone != null)
                {
                    ViewData["userToken"] = _baseToken;

                    c.ViewData.Add("user", _baseAbone.AdSoyad);
                    c.ViewData.Add("KullaniciID", _baseAbone.ObjectId);
                    c.ViewData.Add("AccessToken", _baseToken);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
