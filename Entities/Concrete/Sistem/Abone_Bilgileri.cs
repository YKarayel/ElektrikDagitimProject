using Entities.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete.Sistem
{
    public class ABONE : BaseEntity
    {
        [Display(Name = "Abone No")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboneId { get; set; }

        [Display(Name = "Adı Soyadı")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string AdSoyad { get; set; }

        [Display(Name = "E-Posta Adresi")]
        [MaxLength(80)]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Girilen değer doğru formatta değildir!")]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string Eposta { get; set; }

        [Display(Name = "Şifre")]
        [MaxLength(50)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string Sifre { get; set; } = string.Empty;

        [Display(Name = "Gsm No")]
        [MaxLength(25)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Lütfen doğru formatta giriniz!")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "0 (5##) ### ## ##")]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string GsmNo { get; set; }

        [Display(Name = "TC")]
        [MaxLength(11)]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string TC { get; set; }
        public int YetkiId { get; set; }

        [Display(Name = "Abone Kayıt Tarihi")]
        public DateTime? AbnKayıtTarihi { get; set; }

        public bool Durum { get; set; } = true;


    }
    public class ABONE_LOGIN
    {
        [Display(Name = "E-Posta Adresi")]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string Eposta { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Doldurulması zorunlu alandır!")]
        public string Sifre { get; set; }
    }

    public class ABONE_LOGIN_RESPONSE<T> where T : class
    {
        public ABONE Kullanici { get; set; }
        public List<KULLANICI_YETKI> Yetkiler { get; set; }
        public string Token { get; set; }
    }

    public class ABONE_BORC
    {
        [Key]
        public int AboneBorcId { get; set; }
        [Required]
        public int AboneId { get; set; }
        public double Borclar { get; set; }
    }
}