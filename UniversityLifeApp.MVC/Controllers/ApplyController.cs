using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.AcceptBook;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.RejectBook;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Queries.GetBookBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Queries.GetBookBedRoomRoomById;
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
            var result = (await _mediator.Send(new GetBookBedRoomRoomQuery())).Response;
            return View(result);
        }

        public async Task<IActionResult> Detail(int applyId)
        {
            var result = (await _mediator.Send(new GetBookBedRoomRoomByIdQuery(applyId))).Response;

            return View(result);
        }

        public async Task<IActionResult> Accept(int applyId)
        {
            await _mediator.Send(new AcceptBookCommand(applyId));

            return RedirectToAction("index", "apply");
        }

        public async Task<IActionResult> Reject(int applyId)
        {
            await _mediator.Send(new RejectBookCommand(applyId));

            return RedirectToAction("index" , "apply");
        }
    }
}
