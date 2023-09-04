using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Update;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Update
{
    public class UpdateCommand:IRequest<ApiResult<UpdateResponse>>
    {
        public UpdateCommand(UpdateRequest request)
        {
            Request = request;
        }
        public UpdateRequest Request { get; set; }
    }
}
