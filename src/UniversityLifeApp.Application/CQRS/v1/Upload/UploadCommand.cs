using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Upload
{
    public class UploadCommand:IRequest<ApiResult<UploadResponse>>
    {
        public UploadCommand(UploadRequest request)
        {
            Request = request;
        }
        public UploadRequest Request { get; set; }
    }
}
