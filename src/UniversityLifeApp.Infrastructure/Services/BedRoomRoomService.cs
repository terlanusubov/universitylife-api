using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomRoomService : IBedRoomRoomService
    {
        private readonly ApplicationContext _context;
        public BedRoomRoomService(ApplicationContext context)
            => _context = context;

        public async Task<ApiResult<CreateBedRoomRoomResponse>> CreateBedRoomRoom(CreateBedRoomRoomCommand request)
        {
            
            throw new NotImplementedException();
        }
    }
}
