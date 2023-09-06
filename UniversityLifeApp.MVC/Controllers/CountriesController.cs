using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class CountriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
