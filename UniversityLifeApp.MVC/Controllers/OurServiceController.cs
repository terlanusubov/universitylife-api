using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService;
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

    }
}
