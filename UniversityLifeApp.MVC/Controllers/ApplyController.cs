using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    public class ApplyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public ApplyController(IMediator mediator , ApplicationContext context)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetBookBedRoomRoomResponse()));
            return View(result);
        }
    }
}
