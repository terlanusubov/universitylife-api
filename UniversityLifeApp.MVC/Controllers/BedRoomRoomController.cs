using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Queries.GetBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Queries.GetBedRoomRoomById;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class BedRoomRoomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public BedRoomRoomController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }
        public async Task<IActionResult> Index(GetBedRoomRoomRequest request)
        {
            var result = (await _mediator.Send(new GetBedRoomRoomQuery(request))).Response;
            return View(result);
        }

        public async Task<IActionResult> Create(GetBedRoomRequest request)
        {
            ViewBag.BedRoomRoomTypes = await _context.BedRoomRoomTypes.ToListAsync();
            ViewBag.BedRooms = await _context.BedRooms.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBedRoomRoomRequest request)
        {
            
            var result = await _mediator.Send(new CreateBedRoomRoomCommand(request));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                ViewBag.BedRoomRoomTypes = await _context.BedRoomRoomTypes.ToListAsync();
                ViewBag.BedRooms = await _context.BedRooms.ToListAsync();
                return View(request);
            }
            return RedirectToAction("index", "bedroomroom");
        }

        public async Task<IActionResult> Update(int bedRoomRoomId)
        {
            ViewBag.BedRoomRoomTypes = await _context.BedRoomRoomTypes.ToListAsync();
            ViewBag.BedRooms = await _context.BedRooms.ToListAsync();
            var result = (await _mediator.Send( new GetBedRoomRoomByIdQuery(bedRoomRoomId))).Response;

            UpdateBedRoomRoomRequest request = new UpdateBedRoomRoomRequest
            {
                Name = result.Name,
                BedRoomId = bedRoomRoomId,
                BedRoomRoomTypeId = result.BedRoomRoomTypeId,
                Description = result.Description,
                Price = result.Price,
            };

            TempData["BedRoomRoomId"] = bedRoomRoomId;

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBedRoomRoomRequest request)
        {
            int bedRoomRoomId = (int)TempData["BedRoomRoomId"];
            var result = await _mediator.Send(new UpdateBedRoomRoomCommand(request , bedRoomRoomId));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
                ViewBag.BedRoomRoomTypes = await _context.BedRoomRoomTypes.ToListAsync();
                ViewBag.BedRooms = await _context.BedRooms.ToListAsync();
                return View(request);
            }
            return RedirectToAction("index", "bedroomroom");
        }
    }
}
