using Microsoft.AspNetCore.Mvc;

namespace BancaTCC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
