using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BookBedRoomRoomServiceL : IBookBedRoomRoom
    {
        private readonly ApplicationContext _context;
        public BookBedRoomRoomServiceL(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(int userId, int bedRoomRoomId)
        {
            BedRoomRoomApply bookBedRoomRoom = new BedRoomRoomApply
            {
                UserId = userId,
                BedRoomRoomId = bedRoomRoomId,
                BedRoomRoomApplyStatusId = (int)BedRoomRoomApplyStatusEnum.Pending,
            };

            await _context.BedRoomRoomApplies.AddAsync(bookBedRoomRoom);

            await _context.SaveChangesAsync();

            CreateBookBedRoomRoomResponse response = new CreateBookBedRoomRoomResponse
            {
                UserId = userId,
                BedRoomRoomId = bedRoomRoomId,
            };

            return ApiResult<CreateBookBedRoomRoomResponse>.OK(response);
        }
    }
}
