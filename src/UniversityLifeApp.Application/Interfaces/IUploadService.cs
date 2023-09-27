using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IUploadService
    {
        Task<ApiResult<UploadResponse>> Upload(UploadRequest request);
    }
}
