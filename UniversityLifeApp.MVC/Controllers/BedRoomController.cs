using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.DeleteBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class BedRoomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public BedRoomController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index(GetBedRoomRequest request)
        {
            var result = (await _mediator.Send(new GetBedRoomQuery(request))).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBedRoomRequest request)
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();
            var result = await _mediator.Send(new CreateBedRoomCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "bedroom");
        }

        public async Task<IActionResult> Update(int bedroomId)
        {
            ViewBag.Cities = await _context.Cities.ToListAsync();

            var bedroom = await _context.BedRooms.Where(x => x.Id == bedroomId).Select(x => new UpdateBedRoomRequest
            {
                Name = x.Name,
                Description = x.Description,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CityId = x.CityId,
                DistanceToCenter = x.DistanceToCenter,
                Rating = x.Rating,
                Image = x.BedRoomPhotos.Select(x => x.Name).ToList(),
            }).FirstOrDefaultAsync();

            TempData["bedroomId"] = bedroomId;

            return View(bedroom);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateBedRoomRequest request)
        {
            int bedroomId = (int)TempData["bedroomId"];

            var result = await _mediator.Send(new UpdateBedRoomCommand(request, bedroomId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "bedroom");
        }


        public async Task<IActionResult> Delete(int bedroomId)
        {
            await _mediator.Send(new DeleteBedRoomCommand(bedroomId));

            return RedirectToAction("index", "bedroomId");

        }
    }
}
