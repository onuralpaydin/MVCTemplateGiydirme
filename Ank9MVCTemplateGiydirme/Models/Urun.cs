using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class Urun
	{
		[Key]
		[Required]
		public int UrunId { get; set; }
        [Required]
        public string UrunAdi { get; set; }
        [Required]
        public string UrunTanimi { get; set; }
        [Required]
        [Column(TypeName="decimal(18,2)")]
        public decimal UrunFiyat { get; set; }
        public string UrunResimURL { get; set; }
        [Required]
        [ForeignKey("Kategori")]
        public int KategoriId{ get; set; }
        public Kategori Kategori{ get; set; }
		public List<UrunMalzeme>UrunlerMalzemeler  { get; set; }
	}
}
