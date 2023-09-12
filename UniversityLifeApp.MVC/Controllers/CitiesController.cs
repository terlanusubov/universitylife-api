using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById;
using UniversityLifeApp.Infrastructure.Data;
using UniversityLifeApp.MVC.ViewModels;

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

        public async Task<IActionResult> Update(int cityId)
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();
            
            var city = await _context.Cities.Where(x=>x.Id == cityId).Select(x=> new UpdateCityRequest
            {
                Name = x.Name,
                CountryId = x.CountryId,
                IsTop = x.IsTop,
                Latitude = x.Latitude,
                Longitude = x.Longitude,

            }).FirstOrDefaultAsync();

            TempData["cityId"] = cityId;



            return View(city);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCityRequest request)
        {
            int cityId = (int)TempData["cityId"];

            await _mediator.Send(new UpdateCityCommand(request,cityId));

            return RedirectToAction("index", "cities");
        }

        public async Task<IActionResult> Delete(int cityId)
        {
            await _mediator.Send(new DeleteCityCommand(cityId));

            return RedirectToAction("index", "cities");

        }
    }
}
