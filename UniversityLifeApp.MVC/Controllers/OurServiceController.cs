using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class OurServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
