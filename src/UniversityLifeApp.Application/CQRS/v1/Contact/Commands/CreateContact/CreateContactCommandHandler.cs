using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, ApiResult<CreateContactResponse>>
    {
        private readonly IContactService _contactService;

        public CreateContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public Task<ApiResult<CreateContactResponse>> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var result = _contactService.CreateContact(request);
            return result;
        }
    }
}
