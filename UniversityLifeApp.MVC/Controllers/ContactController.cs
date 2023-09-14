using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Queries.GetCity;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.DeleteContact;
using UniversityLifeApp.Application.CQRS.v1.Contact.Queries.GetContact;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ApplicationContext _context;
        public ContactController(IMediator mediator, ApplicationContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var result = (await _mediator.Send(new GetContactQuery())).Response;

            return View(result);
        }

        public async Task<IActionResult> Delete(int contactId)
        {
            await _mediator.Send(new DeleteContactCommand(contactId));

            return RedirectToAction("index" , "contact");
        }



    }
}
