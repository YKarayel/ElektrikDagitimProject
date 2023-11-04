using Dal.Concrete;
using Dal.Concrete.Sistem;
using Entities.Concrete.Sistem;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ElektrikDagıtım.Api_Sistem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboneController : ControllerBase
    {

        private readonly Kullanici_Islemleri _islemler;

        public AboneController(Kullanici_Islemleri islemler)
        {
            _islemler = islemler;
        }

        private const string TokenSecret = "ForTheLoveOfGodStoreAndLoadThisSecurely";
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


        [HttpPost]
        public IActionResult Yeni_Abone(ABONE abone)
        {
            _islemler.Yeni_Abone(abone);

        }
    }
}
