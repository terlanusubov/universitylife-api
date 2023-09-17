using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.DeleteOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.DeleteOurService
{
    public class DeleteOurServiceCommandHandler : IRequestHandler<DeleteOurServiceCommand, ApiResult<DeleteOurServiceResponse>>
    {
        private readonly IOurServiceService _service;
        public DeleteOurServiceCommandHandler(IOurServiceService service)
        {
            _service = service;
        }
        public async Task<ApiResult<DeleteOurServiceResponse>> Handle(DeleteOurServiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteService(request.Id);
            return result;
        }
    }
}
