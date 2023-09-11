using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.CloseBedRoom.Queries.GetCloseBedroom
{
    public class GetCloseBedRoomQuery:IRequest<ApiResult<GetCloseBedRoomResponse>>
    {
        public GetCloseBedRoomQuery(int universityId)
        {
            UniversityId = universityId;
        }
       public int UniversityId { get; set; }
    }
}
