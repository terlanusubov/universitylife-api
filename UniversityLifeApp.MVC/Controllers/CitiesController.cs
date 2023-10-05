using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById;
using UniversityLifeApp.Infrastructure.Data;
using UniversityLifeApp.MVC.ViewModels;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class CitiesController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _env;
        public CitiesController(IMediator mediator, ApplicationContext context, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _context = context;
            _env = env;
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
            ViewBag.Countries = await _context.Countries.ToListAsync();
            var result = await _mediator.Send(new AddCityCommand(request));


            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            //UploadRequest requestUpload = new UploadRequest
            //{
            //    Folder = "uploads/city",
            //    ImageFile = request.ImageFile,
            //    ImageName = result.Response.Image,
            //};
            //await _mediator.Send(new UploadCommand(requestUpload));

            return RedirectToAction("index", "cities");
        }

        public async Task<IActionResult> Update(int cityId)
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();

            var result = (await _mediator.Send(new GetCityByIdQuery(cityId))).Response;

            UpdateCityRequest request = new UpdateCityRequest
            {
                Name = result.Name,
                Latitude = result.Latitude,
                CountryId = result.CountryId,
                IsTop = result.IsTop,
                Longitude = result.Longitude,
            };

            TempData["cityId"] = cityId;

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCityRequest request)
        {
            ViewBag.Countries = await _context.Countries.ToListAsync();
            int cityId = (int)TempData["cityId"];

            var result = await _mediator.Send(new UpdateCityCommand(request, cityId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            TempData["cityId"] = 0;

            return RedirectToAction("index", "cities");
        }

        public async Task<IActionResult> Delete(int cityId)
        {
            await _mediator.Send(new DeleteCityCommand(cityId));

            return RedirectToAction("index", "cities");

        }
    }
}
