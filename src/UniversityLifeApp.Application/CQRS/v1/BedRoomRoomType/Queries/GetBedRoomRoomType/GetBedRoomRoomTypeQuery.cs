using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Queries.GetBedRoomRoomType
{
    public class GetBedRoomRoomTypeQuery : IRequest<ApiResult<List<GetBedRoomRoomTypeResponse>>>
    {
        public GetBedRoomRoomTypeQuery(GetBedRoomRoomTypeRequest request)
        {
            Request = request;
        }
        public GetBedRoomRoomTypeRequest Request { get; set; }
        public string Name { get; set; }
        public int BedRoomRoomTypeStatusId { get; set; }

        //Bedroom
        public int BedRoomId { get; set; }
    }
}
