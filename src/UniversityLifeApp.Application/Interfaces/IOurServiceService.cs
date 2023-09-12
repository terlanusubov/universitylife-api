using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IOurServiceService
    {
        Task<ApiResult<CreateOurServiceResponse>> CreateService(CreateServiceCommand request);
        Task<ApiResult<List<GetOurServiceResponse>>> GetOurService();
    }
}
