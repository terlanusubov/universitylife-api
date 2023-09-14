using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityLifeApp.MVC.Models;

namespace UniversityLifeApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }
    }
}