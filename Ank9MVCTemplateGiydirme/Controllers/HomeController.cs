using Ank9MVCTemplateGiydirme.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //1. Chef sayfası ilgili kodları VSCODE üzerinden bulup view a entegre ediniz.(AYRI CONTROLLER AÇILACAK.)
        //2.DB CONNECTİON
        //3.SINIFLAR VE PROPS.

        

    }
}