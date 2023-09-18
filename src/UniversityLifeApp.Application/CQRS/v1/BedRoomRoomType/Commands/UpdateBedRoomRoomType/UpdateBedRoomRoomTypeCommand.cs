using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType
{
    public class UpdateBedRoomRoomTypeCommand : IRequest<ApiResult<UpdateBedRoomRoomTypeResponse>>
    {
        public UpdateBedRoomRoomTypeCommand(UpdateBedRoomRoomTypeRequest request , int roomtypeId)
        {

            Request = request;
            RoomTypeId = roomtypeId;

        }

        public int RoomTypeId { get; set; }
        public UpdateBedRoomRoomTypeRequest Request { get; set; }
    }
}
