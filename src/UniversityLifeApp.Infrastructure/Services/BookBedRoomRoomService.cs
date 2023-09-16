using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BookBedRoomRoom.Commands.CreateBookBedRoomRoom;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BookBedRoomRoomService : IBookBedRoomRoom
    {
        private readonly ApplicationContext _context;
        private readonly IEmailService _emailService;
        public BookBedRoomRoomService(ApplicationContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }
        public async Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(CreateBookBedRoomRoomCommand request)
        {
            BedRoomRoomApply bookBedRoomRoom = new BedRoomRoomApply
            {
                UserId = request.Request.UserId,
                BedRoomRoomId = request.Request.BedRoomRoomId,
                BedRoomRoomApplyStatusId = (int)BedRoomRoomApplyStatusEnum.Pending,
            };

            await _context.BedRoomRoomApplies.AddAsync(bookBedRoomRoom);

            await _context.SaveChangesAsync();

            _emailService.Send("huseynove174@gmail.com", "Müraciət", "Yeni bir müraciətiniz var.");

            CreateBookBedRoomRoomResponse response = new CreateBookBedRoomRoomResponse
            {
                UserId = bookBedRoomRoom.UserId,
                BedRoomRoomId = bookBedRoomRoom.BedRoomRoomId,
            };

            return ApiResult<CreateBookBedRoomRoomResponse>.OK(response);
        }
    }
}
