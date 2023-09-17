using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCityById;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    public class BedRoomRoomTypeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _env;
        public BedRoomRoomTypeController(IMediator mediator, ApplicationContext context, IWebHostEnvironment env)
        {
            _mediator = mediator;
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetBedRoomRoomTypeQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.BedRoom = await _context.BedRooms.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBedRoomRoomTypeRequest request)
        {
            var result = await _mediator.Send(new CreateBedRoomRoomTypeCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "bedroomroomtype");
        }

        public async Task<IActionResult> Update(int bedroomroomtypeId)
        {
            ViewBag.BedRoom = await _context.BedRooms.ToListAsync();

            TempData["bedroomroomtypeId"] = bedroomroomtypeId;

            var result = (await _mediator.Send(new GetBedRoomRoomTypeByIdQuery(bedroomroomtypeId))).Response;

            UpdateBedRoomRoomTypeRequest request = new UpdateBedRoomRoomTypeRequest
            {
                Name = result.Name,
                BedRoomId = result.BedRoomId,
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBedRoomRoomTypeRequest request)
        {
            int roomtypeId = (int)TempData["bedroomroomtypeId"];

            var result = await _mediator.Send(new UpdateBedRoomRoomTypeCommand(request, roomtypeId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            TempData["bedroomroomtypeId"] = 0;  

            return RedirectToAction("index", "bedroomroomtype");
        }

        public async Task<IActionResult> Delete(int bedroomroomtypeId)
        {
            await _mediator.Send(new DeleteBedRoomRoomTypeCommand(bedroomroomtypeId));

            return RedirectToAction("index", "bedroomroomtype");

        }
    }
}
