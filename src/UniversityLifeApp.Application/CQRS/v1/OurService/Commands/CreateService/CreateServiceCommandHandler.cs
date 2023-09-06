using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ApiResult<CreateOurServiceResponse>>
    {
        private readonly IOurServiceService _ourService;
        public CreateServiceCommandHandler(IOurServiceService ourService)
        {
            _ourService = ourService;        
        }
        public async Task<ApiResult<CreateOurServiceResponse>> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _ourService.CreateService(request);

            return result;
        }
    }
}
