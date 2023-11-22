using Dal.Concrete.Sistem;
using ElektrikDagıtım.Entities.Concrete.Sistem;
using Entities.Concrete.General;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElektrikDagıtım.Api_Sistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemController : Controller
    {

        private readonly Kullanici_Islemleri _islemler;

        public SistemController(Kullanici_Islemleri islemler)
        {
            _islemler = islemler;
        }

        public const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
        string Yeni_Token(ABONE abone)
        {
            var someClaims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,abone.AdSoyad),
                new Claim(JwtRegisteredClaimNames.Email,abone.Eposta),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenSecret));
            var token = new JwtSecurityToken(
                issuer: "elektrikdagitim.com.tr",
                audience: "elektrikdagitim.com.tr",
                claims: someClaims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [HttpPost("Yeni_Abone")]
        [AllowAnonymous]
        public IActionResult Yeni_Abone([FromBody] ABONE abone)
        {
            var m = _islemler.Yeni_Abone(abone);
            m.AccToken = Yeni_Token(abone);
            return Json(m);
        }

        [HttpGet("Tum_Aboneleri_Getir")]
        public IActionResult Tum_Aboneleri_Getir()
        {
            var m = _islemler.Tum_Aboneleri_Getir();
            return Json(m);
        }

        [HttpPost("Abone_Kontrol")]
        [AllowAnonymous]
        public IActionResult Abone_Kontrol([FromBody] ABONE_LOGIN aboneLogin)
        {
            Mesajlar<ABONE_LOGIN_RESPONSE> m = new Mesajlar<ABONE_LOGIN_RESPONSE>();
            m.Mesaj = "Yetkisiz Kullanıcı";

            var me = _islemler.Abone_Kontrol(aboneLogin.Eposta, aboneLogin.Sifre);
            if (me.Nesne != null)
            {
                m.Nesne = new ABONE_LOGIN_RESPONSE();
                m.Nesne.Abone = me.Nesne;
                m.Nesne.Token = Yeni_Token(me.Nesne);
                m.Durum = true;
                m.Mesaj = me.Mesaj;
            }

            return Json(m);
        }

        [HttpGet("Tum_Kullanici_Yetkileri")]
        public IActionResult Tum_Kullanici_Yetkileri()
        {
            var m = _islemler.Tüm_Kullanıcı_Yetkilerini_Getir();

            return Json(m);
        }

        [HttpGet("Abone_Getir")]
        public IActionResult Abone_Getir([FromHeader] int aboneId)
        {
            var m = _islemler.Abone_Getir(aboneId);

            return Json(m);
        }






    }
}
