using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService
{
    public class CreateServiceCommand:IRequest<ApiResult<CreateOurServiceResponse>>
    {
        public CreateServiceCommand(CreateOurServiceRequest request)
        {
            Request = request;
        }
        public CreateOurServiceRequest Request { get; set; }
    }
}
