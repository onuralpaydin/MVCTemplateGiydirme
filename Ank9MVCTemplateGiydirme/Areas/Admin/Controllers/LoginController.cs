using Ank9MVCTemplateGiydirme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ank9MVCTemplateGiydirme.Areas;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Ank9MVCTemplateGiydirme.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly RestaurantContext _db;

        public LoginController(RestaurantContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Kullanici kullanici)
        {
            if (ModelState.IsValid)
            {
                var dbDekiKullanici = _db.Kullanicilar.FirstOrDefault(x => x.Email == kullanici.Email && x.Sifre==kullanici.Sifre);
                if (dbDekiKullanici!=null)
                {
                    HttpContext.Session.SetString("KullaniciEmail", kullanici.Email);
                    TempData["mesaj"] = "Başarıyla giriş yaptınız";
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                ModelState.AddModelError("", "E-mail veya parola hatalı");
                return View();
            }
            else
            {

            return View();
            }
        }
    }
}
