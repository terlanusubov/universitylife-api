using Microsoft.AspNetCore.Mvc;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.Core;
using MediatR;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniveristyLifeApp.Models.v1.Countries.UpdateCountrt;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.DeleteCity;
using UniveristyLifeApp.Models.v1.Contact.DeleteContact;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.DeleteContact;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry;
using UniveristyLifeApp.Models.v1.Contact.GetContact;
using UniversityLifeApp.Application.CQRS.v1.Contact.Queries.GetContact;

namespace UniversityLifeApp.API.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/Contact")]
    [ApiVersion("1.0")]
    public class ContactController : BaseController
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetContactResponse>>> GetContact()
        => (await _mediator.Send(new GetContactQuery())).Response;
        
        [HttpPost]
        public async Task<ApiResult<CreateContactResponse>> CreateContact(CreateContactRequest request)
            => await _mediator.Send(new CreateContactCommand(request));

        [HttpDelete("{contactId}")]
        public async Task<ApiResult<DeleteContactResponse>> DeleteContact(int contactId)
             => await _mediator.Send(new DeleteContactCommand(contactId));

    }
}
