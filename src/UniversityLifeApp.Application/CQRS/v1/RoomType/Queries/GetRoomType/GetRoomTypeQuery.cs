using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.GetRoomType;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.RoomType.Queries.GetRoomType
{
    public class GetRoomTypeQuery:IRequest<ApiResult<List<GetRoomTypeResponse>>>
    {
        public string Name { get; set; }
    }
}
