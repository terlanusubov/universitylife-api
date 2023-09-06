using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
