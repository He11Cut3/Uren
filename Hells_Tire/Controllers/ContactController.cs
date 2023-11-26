using Microsoft.AspNetCore.Mvc;

namespace Hells_Tire.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
