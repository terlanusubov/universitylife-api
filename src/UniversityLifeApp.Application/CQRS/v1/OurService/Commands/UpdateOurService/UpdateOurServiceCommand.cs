using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.UpdateOurService;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService
{
    public class UpdateOurServiceCommand : IRequest<ApiResult<UpdateOurServiceResponse>>
    {
        public UpdateOurServiceCommand(UpdateOurServiceRequest request, int serviceId)
        {
            Request = request;
            ServiceId = serviceId;
        }
        public UpdateOurServiceRequest Request { get; set; }
        public int ServiceId { get; set; }
    }
}
