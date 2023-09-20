using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType;
using UniveristyLifeApp.Models.v1.RoomType.CreateRoomType;
using UniveristyLifeApp.Models.v1.RoomType.GetRoomType;
using UniveristyLifeApp.Models.v1.RoomType.UpdateRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IRoomTypeService
    {
        Task<ApiResult<CreateRoomTypeResponse>> Create(CreateRoomTypeRequest request);
        Task<ApiResult<List<GetRoomTypeResponse>>> Get();
        Task<ApiResult<UpdateRoomTypeResponse>> Update(UpdateRoomTypeRequest request);
    }
}
