using System.ComponentModel.DataAnnotations;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class Malzeme
	{
		[Key]
		[Required]
		public int MalzemeId { get; set; }

        [Required]
        public string MalzemeAdi { get; set; }
		public List<UrunMalzeme>? UrunMalzemeler { get; set; }

	}
}
