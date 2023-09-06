using Microsoft.AspNetCore.Mvc;

namespace UniversityLifeApp.MVC.Controllers
{
    public class BedRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
