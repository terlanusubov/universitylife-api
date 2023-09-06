using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class CitiesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
