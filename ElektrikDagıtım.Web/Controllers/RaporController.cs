using DevExpress.XtraRichEdit.Import.Html;
using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.ViewModel.Muhasebe;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElektrikDagıtım.Web.Controllers
{
    public class RaporController : BaseController
    {
        public RaporController(IHttpContextAccessor cnt, IConfiguration cfg) : base(cnt, cfg)
        {
        }

        public IActionResult Index()
        {
            return View();
        }


        public class Ftr
        {
            public int ObjectID { get; set; }
        }


        public  IActionResult Fatura_Raporu_Getir(Ftr fatura)
        {

            ViewData["token"] = _baseToken;
            Mesajlar<V_FATURA> rapor = new Mesajlar<V_FATURA>();
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {

                    using (HttpClient client = new HttpClient(handler))
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _baseToken);

                        string url = "http://localhost:40000/api/Muhasebe/V_Fatura_Getir?faturaId="+ fatura.ObjectID;
                        using (var response = client.GetAsync(url))
                        {
                            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var sonuc = response.Result.Content.ReadAsStringAsync();

                                rapor = JsonConvert.DeserializeObject<Mesajlar<V_FATURA>>(sonuc.Result);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(rapor);
        }

        public IActionResult Tahsilat_Raporu_Getir(Ftr tahsilat)
        {

            ViewData["token"] = _baseToken;
            Mesajlar<V_TAHSILAT> rapor = new Mesajlar<V_TAHSILAT>();
            try
            {
                using (HttpClientHandler handler = new HttpClientHandler())
                {

                    using (HttpClient client = new HttpClient(handler))
                    {
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _baseToken);

                        string url = "http://localhost:42000/api/Muhasebe/V_Tahsilat_Listele?tahsilatId=" + tahsilat.ObjectID;
                        using (var response = client.GetAsync(url))
                        {
                            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
                            {
                                var sonuc = response.Result.Content.ReadAsStringAsync();

                                rapor = JsonConvert.DeserializeObject<Mesajlar<V_TAHSILAT>>(sonuc.Result);

                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

            return View(rapor);
        }
    }
}
