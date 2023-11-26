using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hells_Tire.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutController
        public ActionResult Index()
        {
            return View();
        }

    }
}
