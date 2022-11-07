using Microsoft.EntityFrameworkCore;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class RestaurantContext:DbContext
	{
		public RestaurantContext(DbContextOptions<RestaurantContext>options):base(options)
		{

		}

		//TODO DbSET
		//OnModelCreating mockdata seed
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//kategori
			//Urunler
			//Malzeme
			//UrunMalzeme
			//Kullanci

		}
	}
}
