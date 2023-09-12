using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface IGetCloseBedroom
    {
        public Task<ApiResult<GetCloseBedRoomResponse>> GetCloseBedroom(int universityId);
    }
}
