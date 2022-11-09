using Microsoft.AspNetCore.Mvc;

namespace Ank9MVCTemplateGiydirme.Controllers
{
    public class ChefController : Controller
    {
        private readonly ILogger<ChefController> _logger;
        //ILogger ???

        public ChefController(ILogger<ChefController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
