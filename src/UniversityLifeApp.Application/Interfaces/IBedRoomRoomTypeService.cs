using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.DeleteBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomRoomTypeRoomTypeService
    {
        Task<ApiResult<List<GetBedRoomRoomTypeResponse>>> GetBedRoomRoomType();
        Task<ApiResult<GetBedRoomRoomTypeByIdResponse>> GetBedRoomRoomTypeById(int BedRoomRoomTypeId);
        Task<ApiResult<CreateBedRoomRoomTypeResponse>> CreateBedRoomRoomType(CreateBedRoomRoomTypeCommand createBedRoomRoomType);
        Task<ApiResult<UpdateBedRoomRoomTypeResponse>> UpdateBedRoomRoomType(UpdateBedRoomRoomTypeCommand updateBedRoomRoomType, int BedRoomRoomTypeId);
        Task<ApiResult<DeleteBedRoomRoomTypeResponse>> DeleteBedRoomRoomType(int BedRoomRoomTypeId);
    }
}
