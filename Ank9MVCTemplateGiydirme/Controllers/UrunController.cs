using Ank9MVCTemplateGiydirme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class UrunController : Controller
    {
        private readonly RestaurantContext _db;

        public UrunController(RestaurantContext db)
        {
           _db = db;
        }
        public IActionResult Index()
        {

            var bununTipiNe = _db.Urunler.Include(x => x.Kategori).Include(x => x.UrunlerMalzemeler).ThenInclude(x => x.Malzeme).OrderByDescending(x => x.UrunId).ToList();

            return View(bununTipiNe);
        }
    }
}
