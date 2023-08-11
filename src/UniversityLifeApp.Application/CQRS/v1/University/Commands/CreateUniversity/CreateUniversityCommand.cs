using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity
{
    public class CreateUniversityCommand:IRequest<ApiResult<CreateUniversityResponse>>
    {
        public CreateUniversityCommand(CreateUniversityRequest request)
        {
            Request = request;
        }

        public CreateUniversityRequest Request { get; set; }
    }
}
