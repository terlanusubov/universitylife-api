using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniveristyLifeApp.Models.v1.University.DeleteUniversity;
using UniveristyLifeApp.Models.v1.University.GetUniversity;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IUniversityService
    {
        Task<ApiResult<CreateUniversityResponse>> Create(CreateUniversityCommand request);
        Task<ApiResult<UpdateUniversityResponse>> Update(UpdateUniversityCommand request, int universityId);
        Task<ApiResult<List<GetUniversityResponse>>> Get();
        Task<ApiResult<DeleteUniversityResponse>> Delete(int universityId);
    }
}
