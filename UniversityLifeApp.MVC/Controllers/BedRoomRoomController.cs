using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;

namespace UniversityLifeApp.MVC.Controllers
{
    public class BedRoomRoomController : Controller
    {
        private readonly IMediator _mediator;

        public BedRoomRoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
           // var result = (await _mediator.Send(new GetBedRoomQuery)
            return View();
        }
    }
}
