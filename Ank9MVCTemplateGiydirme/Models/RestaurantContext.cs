using Microsoft.EntityFrameworkCore;

namespace Ank9MVCTemplateGiydirme.Models
{
	public class RestaurantContext:DbContext
	{
		public RestaurantContext(DbContextOptions<RestaurantContext>options):base(options)
		{
			
		}
		public DbSet<Kategori> Kategoriler { get; set; }
		public DbSet<Malzeme> Malzemeler { get; set; }
		public DbSet<Urun> Urunler { get; set; }
		public DbSet<UrunMalzeme> UrunlerMalzemeler { get; set; }
		public DbSet<Kullanici> Kullanicilar { get; set; }

		//FLUENT API MANY-MANY
		//TODO DbSET
		//OnModelCreating mockdata seed
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<UrunMalzeme>().HasKey(x => new { x.UrunId, x.MalzemeId });
			modelBuilder.Entity<Kullanici>().HasData(new Kullanici
			{
				KullaniciId = 1,
				Email = "info@example.com",
				Sifre = "1234"
			});

		}
	}
}
