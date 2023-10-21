using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurServiceById;
using UniveristyLifeApp.Models.v1.OurService.UpdateOurService;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.DeleteOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurServiceById;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class OurServiceController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public OurServiceController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetOurServiceQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOurServiceRequest request)
        {
            var result = await _mediator.Send(new CreateServiceCommand(request));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index" , "ourservice");
        }

        public async Task<IActionResult> Update(int serviceId)
        {
            TempData["ServiceId"] = serviceId;
            var result = (await _mediator.Send(new GetOurServiceByIdQuery(serviceId))).Response;

            UpdateOurServiceRequest request = new UpdateOurServiceRequest
            {
                Name = result.Name,
                Description = result.Description,
                
            };

            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateOurServiceRequest request)
        {
            int serviceId = (int)TempData["ServiceId"];
            
            var result = await _mediator.Send(new UpdateOurServiceCommand(request, serviceId));

            if (result.StatusCode != (int)HttpStatusCode.OK)
            {
                foreach (var item in result.ErrorList)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }

                return View(request);
            }

            return RedirectToAction("index", "ourservice");
        }


        public async Task<IActionResult> Delete(int ourserviceId)
        {
            await _mediator.Send(new DeleteOurServiceCommand(ourserviceId));

            return RedirectToAction("index", "ourservice");
        }
    }
}
