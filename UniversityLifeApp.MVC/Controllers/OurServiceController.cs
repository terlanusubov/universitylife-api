using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurServiceById;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
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
            await _mediator.Send(new CreateServiceCommand(request));

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
            
            await _mediator.Send(new UpdateOurServiceCommand(request, serviceId));

            return RedirectToAction("index", "ourservice");
        }

    }
}
