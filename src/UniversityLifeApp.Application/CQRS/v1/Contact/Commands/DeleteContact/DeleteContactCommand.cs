using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Contact.DeleteContact;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Contact.Commands.DeleteContact
{
    public class DeleteContactCommand:IRequest<ApiResult<DeleteContactResponse>>
    {
        public DeleteContactCommand(int contactid)
        {
            Contactid = contactid;
        }
        public int Contactid { get; set; }
    }
}
