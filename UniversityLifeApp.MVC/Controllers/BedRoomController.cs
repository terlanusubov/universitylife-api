using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
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
            await _mediator.Send(new CreateBedRoomCommand(request));
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

            }).FirstOrDefaultAsync();

            TempData["bedroomId"] = bedroomId;

            return View(bedroom);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateBedRoomRequest request)
        {
            int bedroomId = (int)TempData["bedroomId"];

            await _mediator.Send(new UpdateBedRoomCommand(request, bedroomId));

            return RedirectToAction("index", "bedroom");
        }
    }
}
