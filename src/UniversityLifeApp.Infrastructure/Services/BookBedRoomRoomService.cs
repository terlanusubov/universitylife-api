using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
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

        public async Task<ApiResult<List<GetBookBedRoomRoomResponse>>> GetBookBedRoomRoom()
        {
            var bookbed = await _context.BedRoomRoomApplies.Include(x => x.BedRoomRoom).Include(x => x.User).Select(x => new GetBookBedRoomRoomResponse
            {
                Id = x.Id,
                Fullname = x.User.Name + " " + x.User.Surname,
                Price = x.BedRoomRoom.Price,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                BedRoomRoomName = x.BedRoomRoom.Name,
                BedRoomName = x.BedRoomRoom.BedRoom.Name,
                BedRoomRoomType = x.BedRoomRoom.BedRoomRoomType.Name
                

            }).ToListAsync();


            return ApiResult<List<GetBookBedRoomRoomResponse>>.OK(bookbed);


        }
    }
}
