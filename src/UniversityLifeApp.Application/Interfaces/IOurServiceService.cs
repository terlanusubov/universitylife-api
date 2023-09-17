using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.DeleteOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurServiceById;
using UniveristyLifeApp.Models.v1.OurService.UpdateOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.DeleteOurService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IOurServiceService
    {
        Task<ApiResult<CreateOurServiceResponse>> CreateService(CreateServiceCommand request);
        Task<ApiResult<List<GetOurServiceResponse>>> GetOurService();
        Task<ApiResult<GetOurServiceResponse>> GetById(int serviceId);
        Task<ApiResult<UpdateOurServiceResponse>> UpdateService(UpdateOurServiceCommand request, int serviceId);
        Task<ApiResult<DeleteOurServiceResponse>> DeleteService(int serviceId);

    }
}
