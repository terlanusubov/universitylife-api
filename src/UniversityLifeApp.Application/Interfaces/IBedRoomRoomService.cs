using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoomById;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IBedRoomRoomService
    {
        Task<ApiResult<CreateBedRoomRoomResponse>> CreateBedRoomRoom(CreateBedRoomRoomCommand request);
        Task<ApiResult<List<GetBedRoomRoomResponse>>> GetBedRoomRoom(GetBedRoomRoomRequest request);
        Task<ApiResult<GetBedRoomRoomByIdResponse>> GetBedRoomRoomById(int bedRoomRoomId);
        Task<ApiResult<UpdateBedRoomRoomResponse>> UpdateBedRoomRoom(UpdateBedRoomRoomCommand request, int bedRoomRoomId);
        Task<ApiResult<DeleteBedRoomRoomResponse>> Delete(int bedRoomRoomId);
    }
}