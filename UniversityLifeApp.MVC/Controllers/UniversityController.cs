using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.DeleteUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Queries.GetUniversityById;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class UniversityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public UniversityController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetUniversityQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUniversityRequest request)
        {
            var result = await _mediator.Send(new CreateUniversityCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }
            return RedirectToAction("index", "university");
        }

        public async Task<IActionResult> Update(int universityId)
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();

            var result = (await _mediator.Send(new GetUniversityByIdQuery(universityId))).Response;

            UpdateUniversityRequest request = new UpdateUniversityRequest
            {
                Name = result.Name,
                CityId = result.CityId,
                Latitude = result.Latitude,
                Longitude = result.Longitude,
            };

            TempData["universityId"] = universityId;



            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateUniversityRequest request)
        {
            int universityId = (int)TempData["universityId"];

            var result = await _mediator.Send(new UpdateUniversityCommand(request, universityId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "university");
        }

        public async Task<IActionResult> Delete(int universityId)
        {
            await _mediator.Send(new DeleteUniversityCommand(universityId));
            return RedirectToAction("index", "university");
        }
    }
}
