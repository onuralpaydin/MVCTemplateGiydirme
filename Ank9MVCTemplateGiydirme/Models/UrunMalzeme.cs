using System.ComponentModel.DataAnnotations.Schema;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class UrunMalzeme
	{
		[ForeignKey("Malzeme")]
		public int MalzemeId { get; set; }

		public Malzeme Malzeme { get; set; }

		[ForeignKey("Urun")]
		public int UrunId { get; set; }

		public Urun Urun { get; set; }
	}
}
