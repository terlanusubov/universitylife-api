using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact
{
    public class CreateContactCommand:IRequest<ApiResult<CreateContactResponse>>
    {
        public CreateContactCommand(CreateContactRequest request)
        {
            Request = request;
        }
        public CreateContactRequest Request { get; set; }
    }
}
