using Microsoft.AspNetCore.Mvc;

namespace SalesWebApp.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
