using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.CreateBedRoomRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoom.Commands.UpdateBedRoomRoom;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
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
            BedRoomRoom bedRoomRoom = new BedRoomRoom
            {
                BedRoomId = request.Request.BedRoomId,
                BedRoomRoomTypeId = request.Request.BedRoomRoomTypeId,
                Description = request.Request.Description,
                Name = request.Request.Name,
                Price = request.Request.Price,
                BedRoomRoomStatusId = (int)BedRoomRoomStatusEnum.Active,
            };

            await _context.AddAsync(bedRoomRoom);
            await _context.SaveChangesAsync();

            var response = new CreateBedRoomRoomResponse
            {
                Price = bedRoomRoom.Price,
                Name = bedRoomRoom.Name,
                Description = bedRoomRoom.Description,
                BedRoomId = bedRoomRoom.BedRoomId,
                BedRoomRoomTypeId = bedRoomRoom.BedRoomRoomTypeId
            };

            return ApiResult<CreateBedRoomRoomResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteBedRoomRoomResponse>> Delete(int bedRoomRoomId)
        {
            var bedRoomRoom = await _context.BedRoomRooms.Where(x => x.Id == bedRoomRoomId).FirstOrDefaultAsync();

            bedRoomRoom.BedRoomRoomStatusId = (int)BedRoomRoomStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            var response = new DeleteBedRoomRoomResponse
            {
                Price = bedRoomRoom.Price,
                Name = bedRoomRoom.Name,
                Description = bedRoomRoom.Description,
                BedRoomId = bedRoomRoom.BedRoomId,
                BedRoomRoomTypeId = bedRoomRoom.BedRoomRoomTypeId,
                BedRoomRoomStatusId = bedRoomRoom.BedRoomRoomStatusId,
                
            };

            return ApiResult<DeleteBedRoomRoomResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetBedRoomRoomResponse>>> GetBedRoomRoom(GetBedRoomRoomRequest request)
        {
            var bedRoomRooms = await _context.BedRoomRooms.Where(x => x.BedRoomRoomStatusId == (int)BedRoomRoomStatusEnum.Active && (request.BedRoomRoomId != null ? x.Id == request.BedRoomRoomId : true) && (request.BedRoomRoomTypeId != null ? x.BedRoomRoomTypeId == request.BedRoomRoomTypeId : true)).Select(x => new GetBedRoomRoomResponse
            {
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                BedRoomId= x.BedRoomId,
                BedRoomRoomTypeId = x.BedRoomRoomTypeId
            }).ToListAsync();

            return ApiResult<List<GetBedRoomRoomResponse>>.OK(bedRoomRooms);
        }

        public async Task<ApiResult<UpdateBedRoomRoomResponse>> UpdateBedRoomRoom(UpdateBedRoomRoomCommand request, int bedRoomRoomId)
        {
            var bedRoomRoom = await _context.BedRoomRooms.Where(x => x.Id == bedRoomRoomId).FirstOrDefaultAsync();

            bedRoomRoom.Name = request.Request.Name;
            bedRoomRoom.Description = request.Request.Description;
            bedRoomRoom.BedRoomId = request.Request.BedRoomId;
            bedRoomRoom.BedRoomRoomTypeId = request.Request.BedRoomRoomTypeId;
            bedRoomRoom.Price = request.Request.Price;

            await _context.SaveChangesAsync();

            var response = new UpdateBedRoomRoomResponse
            {
                Price = bedRoomRoom.Price,
                Name = bedRoomRoom.Name,
                Description = bedRoomRoom.Description,
                BedRoomId = bedRoomRoom.BedRoomId,
                BedRoomRoomTypeId = bedRoomRoom.BedRoomRoomTypeId,
                BedRoomRoomStatusId = bedRoomRoom.BedRoomRoomStatusId,
            };

            return ApiResult<UpdateBedRoomRoomResponse>.OK(response);
        }
    }
}
