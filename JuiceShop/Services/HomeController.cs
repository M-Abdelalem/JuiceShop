using Microsoft.AspNetCore.Mvc;

namespace JuiceShop.Services
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
