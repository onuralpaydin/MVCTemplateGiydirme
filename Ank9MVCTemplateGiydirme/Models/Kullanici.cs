using Microsoft.AspNetCore.Http;

namespace Ank9MVCTemplateGiydirme.Models
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string Email { get; set; }
        public string Sifre { get; set; }

        //public string KullaniciRolu { get; set; }
    }
}
