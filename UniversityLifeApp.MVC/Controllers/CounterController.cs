using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Counter.Queries.GetCounter;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    public class CounterController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public CounterController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetCounterQuery())).Response;

            return View(result);
        }
    }
}
