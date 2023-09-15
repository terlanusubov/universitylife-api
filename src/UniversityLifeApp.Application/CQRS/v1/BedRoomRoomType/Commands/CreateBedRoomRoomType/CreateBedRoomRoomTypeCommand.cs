using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType
{
    public class CreateBedRoomRoomTypeCommand : IRequest<ApiResult<CreateBedRoomRoomTypeResponse>>
    {
        public CreateBedRoomRoomTypeCommand(CreateBedRoomRoomTypeRequest request)
        {
            Request = request;
        }

        public CreateBedRoomRoomTypeRequest Request { get; set; }
    }
}
