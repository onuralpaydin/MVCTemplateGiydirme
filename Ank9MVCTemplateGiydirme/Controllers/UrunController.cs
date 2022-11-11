using Ank9MVCTemplateGiydirme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class UrunController : Controller
    {
        private readonly RestaurantContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UrunController(RestaurantContext db,IWebHostEnvironment webHostEnvironment)
        {
           _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {

            var bununTipiNe = _db.Urunler.Include(x => x.Kategori).Include(x => x.UrunlerMalzemeler).ThenInclude(x => x.Malzeme).OrderByDescending(x => x.UrunId).ToList();

            //IWebHostEnvironment
            //IformFile
           

            return View(bununTipiNe);
        }

        

        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(),"KategoriId","KategoriAdi");
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Urun urun,IFormFile resim)
        {
            ResimKontrolleri(resim);
            if (ModelState.IsValid)
            {
                urun.UrunResimURL = ResimYukle(resim);
                _db.Urunler.Add(urun);
                _db.SaveChanges();
                return RedirectToAction("Index", "Urun");
            }
            ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(), "KategoriId", "KategoriAdi");
            return View();
        }

        private string ResimYukle(IFormFile resim)
        {
            string ext = Path.GetExtension(resim.FileName);
            string resimAd = Guid.NewGuid() + ext;
            string dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "images", "uploads",resimAd);
            using (var stream = new FileStream(dosyaYolu, FileMode.Create))
            {
                resim.CopyTo(stream);
            }
            return resimAd;
        }

        private void ResimKontrolleri(IFormFile resim)
        {
            string[] izinVerilenler = { ".jpg", ".png", ".jpeg" };
            if (resim!=null)
            {
                string ext = Path.GetExtension(resim.FileName);
                if (!izinVerilenler.Contains(ext))
                {
                    ModelState.AddModelError("resim", "İzin verilen dosya uzantıları jpeg,jpg,png");
                }
                else if (resim.Length>1000*1000*1)//1 mb tekabül eder.
                {
                    ModelState.AddModelError("resim", "Maksimum Dosya Boyutu 1MB.");

                }

            }
            else
            {
                ModelState.AddModelError("resim", "Resim Zorunludur");

            }
        }

        private void ResimSil(string urunResimURL)
        {
            if (!string.IsNullOrEmpty(urunResimURL)) ;
            {
                var yoluSil = Path.Combine(_webHostEnvironment.WebRootPath, "images", "uploads",urunResimURL);
                if (System.IO.File.Exists(yoluSil))
                {
                    System.IO.File.Delete(yoluSil);
                }

            }
           
        }

    }
}
