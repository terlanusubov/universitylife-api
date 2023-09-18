using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.UpdateOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService
{
    public class UpdateOurServiceCommandHandler : IRequestHandler<UpdateOurServiceCommand, ApiResult<UpdateOurServiceResponse>>
    {
        private readonly IOurServiceService _service;
        public UpdateOurServiceCommandHandler(IOurServiceService service)
        {
            _service = service;
        }
        public async Task<ApiResult<UpdateOurServiceResponse>> Handle(UpdateOurServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateService(request,request.ServiceId);
            return result;
        }
    }
}
    