using Ank9MVCTemplateGiydirme.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class KategoriController : Controller
    {
        private readonly RestaurantContext _db;

        public KategoriController(RestaurantContext db)
        {
            _db = db;
        }

        //CRUD
        public IActionResult Index()//LİSTELEME
        {
           List<Kategori> kategoriler = _db.Kategoriler.ToList();
            return View(kategoriler);
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Yeni(string KategoriAdi)
        {
            if (!string.IsNullOrEmpty(KategoriAdi))
            {

            Kategori yeniKategori = new Kategori();
            yeniKategori.KategoriAdi = KategoriAdi;
            _db.Kategoriler.Add(yeniKategori);
            _db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Duzenle(int KategoriId)
        {
            Kategori arananKategori = _db.Kategoriler.FirstOrDefault(x => x.KategoriId == KategoriId);
            if (arananKategori==null)
            {
                return NotFound();
            }
            return View(arananKategori);
        }

        [HttpPost]
        public IActionResult Duzenle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _db.Kategoriler.Update(kategori);
                _db.SaveChanges();
                return RedirectToAction("Index", "Kategori");

            }
            return View();

        }

        public IActionResult Sil(int? kategoriId)
        {
            if (kategoriId==null)
            {
                return RedirectToAction("Index", "Kategori");
            }
           Kategori kategori = _db.Kategoriler.Find(kategoriId);
            if (kategori==null)
            {
                return NotFound();
            }
            _db.Kategoriler.Remove(kategori);
            _db.SaveChanges();
            return RedirectToAction("Index", "Kategori");
        }

        //[HttpPost]
        //[ActionName("Sil")]
        //public IActionResult SilPost(Kategori kategori)
        //{
           

        //}
    }
}
