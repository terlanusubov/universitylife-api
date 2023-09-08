using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Contact.DeleteContact;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, ApiResult<DeleteContactResponse>>
    {
        private readonly IContactService _contactService;

        public DeleteContactCommandHandler(IContactService contactService)
        {
            _contactService = contactService;
        }
        public Task<ApiResult<DeleteContactResponse>> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var result = _contactService.DeleteContact(request.Contactid);
            return result;
        }
    }
}
