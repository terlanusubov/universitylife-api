using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Upload
{
    public class UploadCommandHandler : IRequestHandler<UploadCommand, ApiResult<UploadResponse>>
    {
        private readonly IUploadService _uploadService;
        public UploadCommandHandler(IUploadService uploadService)
        {
            _uploadService = uploadService;
        }
        public async Task<ApiResult<UploadResponse>> Handle(UploadCommand request, CancellationToken cancellationToken)
        {
            var result = await _uploadService.Upload(request.Request);

            return result;
        }
    }
}
