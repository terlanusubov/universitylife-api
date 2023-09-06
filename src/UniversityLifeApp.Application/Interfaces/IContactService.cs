using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Contact.AddContact;
using UniveristyLifeApp.Models.v1.Contact.DeleteContact;
using UniveristyLifeApp.Models.v1.Contact.GetContact;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Contact.Commands.CreateContact;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IContactService
    {
        Task<ApiResult<List<GetContactResponse>>> GetContact();
        Task<ApiResult<CreateContactResponse>> CreateContact(CreateContactCommand request);
        Task<ApiResult<DeleteContactResponse>> DeleteContact(int contactId);

    }
}
