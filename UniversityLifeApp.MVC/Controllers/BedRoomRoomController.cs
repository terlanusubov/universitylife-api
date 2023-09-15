using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoom;

namespace UniversityLifeApp.MVC.Controllers
{
    public class BedRoomRoomController : Controller
    {
        private readonly IMediator _mediator;

        public BedRoomRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(GetBedRoomRoomRequest request)
        {
            var result = (await _mediator.Send(new GetBedRoomRoomQuery(request))).Response;
            return View(result);
        }

        public async Task<IActionResult> Create(GetBedRoomRequest request)
        {
            //ViewBag.BedRoomRoomTypes = await _mediator.Send(new)
            ViewBag.BedRooms = await _mediator.Send(new GetBedRoomQuery(request));
            return View();
        }
    }
}
