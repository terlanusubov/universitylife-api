using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public CitiesController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        
        public async Task<IActionResult> Index(GetCityRequest request)
        {
            var result = (await _mediator.Send(new GetCityQuery(request))).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCityRequest request)
        {
            await _mediator.Send(new AddCityCommand(request));
            return RedirectToAction("index", "cities");
        }
    }
}
