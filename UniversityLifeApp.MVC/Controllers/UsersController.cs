using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
