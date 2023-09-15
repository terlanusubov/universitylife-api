using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.DeleteBedRoomRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.DeleteBedRoomRoomType
{
    public class DeleteBedRoomRoomTypeCommand : IRequest<ApiResult<DeleteBedRoomRoomTypeResponse>>
    {
        public DeleteBedRoomRoomTypeCommand(int bedroomroomTypeId)
        {
            BedRoomRoomTypeId = bedroomroomTypeId;
        }

        public int BedRoomRoomTypeId { get; set; }
        //public DeleteBedRoomRoomTypeRequest Request { get; set; }
    }
}
