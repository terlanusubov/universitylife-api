using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomTypeById;

namespace UniversityLifeApp.MVC.Controllers
{
    public class BedRoomRoomTypeController : Controller
    {
        private readonly IMediator _mediator;
        public BedRoomRoomTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> Index(GetBedRoomRoomTypeRequest request)
        {
            var types = (await _mediator.Send(new GetBedRoomRoomTypeQuery(request))).Response;

            return View(types);
        }

        public async Task<IActionResult> Create()
        {
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
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var type = (await _mediator.Send(new GetBedRoomRoomTypeByIdQuery(id))).Response;

            UpdateBedRoomRoomTypeRequest request = new UpdateBedRoomRoomTypeRequest
            {
                Name = type.Name,
            };

            TempData["TypeId"] = id;

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBedRoomRoomTypeRequest request)
        {
            int typeId = (int)TempData["TypeId"];
            var result = await _mediator.Send(new UpdateBedRoomRoomTypeCommand(request, typeId));

            if(result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBedRoomRoomTypeCommand(id));
            return RedirectToAction("index");
        }
    }
}
