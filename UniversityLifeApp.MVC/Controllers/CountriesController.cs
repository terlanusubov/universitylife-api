using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.AddCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.DeleteCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Commands.UpdateCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class CountriesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public CountriesController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetCountryQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCountryRequest request)
        {
            var result = await _mediator.Send(new AddCountryCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }
            return RedirectToAction("index", "countries");
        }

        public async Task<IActionResult> Update(int countriesId)
        {

            var country = await _context.Countries.Where(x => x.Id == countriesId).Select(x => new UpdateCountryRequest
            {
                Name = x.Name,

            }).FirstOrDefaultAsync();

            TempData["countriesId"] = countriesId;



            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryRequest request)
        {
            int countriesId = (int)TempData["countriesId"];

            var result = await _mediator.Send(new UpdateCountryCommand(request, countriesId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "countries");
        }

        public async Task<IActionResult> Delete (int countryId)
        {
            await _mediator.Send(new DeleteCountryCommand(countryId));

            return RedirectToAction("index", "countries");
        }
    }
}
