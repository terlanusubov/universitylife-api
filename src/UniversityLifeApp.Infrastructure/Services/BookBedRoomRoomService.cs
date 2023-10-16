using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.AcceptBook;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.CreateBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.DeleteBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoom;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.GetBookBedRoomRoomById;
using UniveristyLifeApp.Models.v1.BookBedRoomRoom.RejectBook;
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
        private readonly IConfiguration _configuration;
        public BookBedRoomRoomService(ApplicationContext context, IEmailService emailService, IConfiguration configuration)
        {
            _context = context;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<ApiResult<AcceptBookResponse>> Accept(int id)
        {
            var apply = await _context.BedRoomRoomApplies.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(apply != null)
            {
                apply.BedRoomRoomApplyStatusId = (int)BedRoomRoomApplyStatusEnum.Accepted;
            }

            await _context.SaveChangesAsync();

            AcceptBookResponse response = new AcceptBookResponse
            {
                Id = apply.Id
            };

            return ApiResult<AcceptBookResponse>.OK(response);
        }

        public async Task<ApiResult<CreateBookBedRoomRoomResponse>> BookBedRoomRoom(CreateBookBedRoomRoomCommand request)
        {

            var books = await _context.BedRoomRoomApplies.ToListAsync();
            foreach (var item in books)
            {
                if(item.UserId == request.Request.UserId && item.BedRoomRoomId == request.Request.BedRoomRoomId)
                {
                    return ApiResult<CreateBookBedRoomRoomResponse>.Error(ErrorCodes.APPLY_IS_ALREADY_EXIST, null, (int)HttpStatusCode.AlreadyReported);
                }
            }
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

        public async Task<ApiResult<DeleteBookBedRoomRoomResponse>> Delete(int bookId)
        {
            var book = await _context.BedRoomRoomApplies.Where(x => x.Id == bookId).FirstOrDefaultAsync();

            if(book == null)
            {
                Dictionary<string,string> error = new Dictionary<string, string>();

                error.Add("Id", "Apply is not exist.");
                return ApiResult<DeleteBookBedRoomRoomResponse>.Error(ErrorCodes.DATA_IS_NOT_EXIST , error);
            }

            _context.BedRoomRoomApplies.Remove(book);

            await _context.SaveChangesAsync();

            DeleteBookBedRoomRoomResponse response = new DeleteBookBedRoomRoomResponse
            {
                Id = book.Id,
            };

            return ApiResult<DeleteBookBedRoomRoomResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetBookBedRoomRoomResponse>>> GetBookBedRoomRoom(GetBookBedRoomRoomRequest request)
        {
            var baseUrl = _configuration["BaseUrl"];
            var bookbed = await _context.BedRoomRoomApplies.Include(x => x.BedRoomRoom).Include(x => x.User).Where(x => request.UserId != null ? x.UserId == request.UserId : true).Select(x => new GetBookBedRoomRoomResponse
            {
                Id = x.Id,
                Fullname = x.User.Name + " " + x.User.Surname,
                Price = x.BedRoomRoom.Price,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                BedRoomRoomName = x.BedRoomRoom.Name,
                BedRoomName = x.BedRoomRoom.BedRoom.Name,
                BedRoomRoomType = x.BedRoomRoom.RoomType.BedRoomRoomType.Name,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Image = x.BedRoomRoom.BedRoomRoomPhotos.Select(x => baseUrl + "bedroomPhoto/" + x.Name).FirstOrDefault(),
                BedRoomRoomApplyStatusId = x.BedRoomRoomApplyStatusId,
            }).ToListAsync();

            return ApiResult<List<GetBookBedRoomRoomResponse>>.OK(bookbed);


        }

        public async Task<ApiResult<GetBookBedRoomRoomByIdResponse>> GetById(int id)
        {
            var bedroom = await _context.BedRoomRoomApplies.Where(x => x.Id == id).Select(x => new GetBookBedRoomRoomByIdResponse
            {
                Id = x.Id,
                Fullname = x.User.Name + " " + x.User.Surname,
                Price = x.BedRoomRoom.Price,
                Email = x.User.Email,
                PhoneNumber = x.User.PhoneNumber,
                Description = x.BedRoomRoom.Description,
                BedRoomRoomName = x.BedRoomRoom.Name,
                BedRoomName = x.BedRoomRoom.BedRoom.Name,
                BedRoomRoomType = x.BedRoomRoom.RoomType.BedRoomRoomType.Name,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Image = x.BedRoomRoom.BedRoomRoomPhotos.Select(x => "http://highresultech-001-site1.ftempurl.com/uploads/bedRoomRoomPhotos/" + x.Name).FirstOrDefault(),
                BedRoomRoomApplyStatusId = x.BedRoomRoomApplyStatusId,
            }).FirstOrDefaultAsync();

            return ApiResult<GetBookBedRoomRoomByIdResponse>.OK(bedroom);
        }
      

        public async Task<ApiResult<RejectBookResponse>> Reject(int id)
        {
            var apply = await _context.BedRoomRoomApplies.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (apply != null)
            {
                apply.BedRoomRoomApplyStatusId = (int)BedRoomRoomApplyStatusEnum.Rejected;
            }

            await _context.SaveChangesAsync();

            RejectBookResponse response = new RejectBookResponse
            {
                Id = apply.Id
            };

            return ApiResult<RejectBookResponse>.OK(response);
        }
    }
}