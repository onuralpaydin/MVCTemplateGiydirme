using Microsoft.AspNetCore.Mvc;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            return View();
        }
    }
}
