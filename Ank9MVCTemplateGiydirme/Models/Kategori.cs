using System.ComponentModel.DataAnnotations;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class Kategori
	{
		[Key]
		[Required]
		public int KategoriId { get; set; }
		[Required]
		public string KategoriAdi { get; set; }
		public List<Urun>? Urunler { get; set; }
	}
}
