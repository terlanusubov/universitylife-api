using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
