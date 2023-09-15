using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Countries.GetCountry;
using UniversityLifeApp.Application.CQRS.v1.Countryies.Query.GetCountry;
using UniversityLifeApp.Application.Core;
using UniveristyLifeApp.Models.v1.Contact.GetContact;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Queries.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ApiResult<List<GetContactResponse>>>
    {
        private readonly IContactService _contactService;

        public GetContactQueryHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public Task<ApiResult<List<GetContactResponse>>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var result = _contactService.GetContact();
            return result;
        }
    }
}
