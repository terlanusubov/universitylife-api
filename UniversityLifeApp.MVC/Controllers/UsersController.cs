using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.Account.GetAccount;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Delete;
using UniversityLifeApp.Application.CQRS.v1.Account.Query.GetAccount;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.DeleteContact;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    //[Area("admin")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public UsersController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index(GetAccountRequest request)
        {
            var result = (await _mediator.Send(new GetAccountQuery(request))).Response;

            return View(result);
        }

        public async Task<IActionResult> Delete(int userId)
        {
            await _mediator.Send(new DeleteAccountCommand(userId));

            return RedirectToAction("index", "users");
        }
    }
}
