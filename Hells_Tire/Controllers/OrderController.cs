using Microsoft.AspNetCore.Mvc;

namespace Hells_Tire.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
