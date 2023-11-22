using ElektrikDagıtım.Entities.Concrete.Muhasebe;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using ElektrikDagıtım.Entities.ViewModel.Muhasebe;
using ElektrikDagıtım.Web.Controllers;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ElektrikDagıtım.Web.Areas.Muhasebe.Controllers
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

        //    [HttpGet]
        //    public async Task<IActionResult> Faturalari_Getir()
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            try
        //            {
        //                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _baseToken);
        //                client.DefaultRequestHeaders.Add("aboneId", _baseAbone.ObjectId.ToString());
        //                HttpResponseMessage response = await client.GetAsync("http://localhost:40000/api/Muhasebe/Abone_Tum_Faturalari_Getir");

        //                if (response.IsSuccessStatusCode)
        //                {
        //                    var content = await response.Content.ReadAsStringAsync();
        //                    Mesajlar<FATURA> mFatura = JsonConvert.DeserializeObject<Mesajlar<FATURA>>(content);
        //                    List<FATURA> fatura = mFatura.Liste;
        //                }
        //                else
        //                    Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");


        //            }
        //            catch (HttpRequestException e)
        //            {
        //                Console.WriteLine($"Hata: {e.Message}");
        //            }
        //        }
        //        return 
    }

}
