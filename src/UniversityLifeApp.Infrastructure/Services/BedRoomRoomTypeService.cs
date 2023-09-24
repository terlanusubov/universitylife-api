using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.CreateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.DeleteBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomType;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.GetBedRoomRoomTypeById;
using UniveristyLifeApp.Models.v1.BedRoomRoomType.UpdateBedRoomRoomType;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.CreateBedRoomRoomType;
using UniversityLifeApp.Application.CQRS.v1.BedRoomRoomType.Commands.UpdateBedRoomRoomType;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomRoomTypeService : IBedRoomRoomTypeRoomTypeService
    {
        private readonly ApplicationContext _context;
        public BedRoomRoomTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<CreateBedRoomRoomTypeResponse>> CreateBedRoomRoomType(CreateBedRoomRoomTypeCommand createBedRoomRoomType)
        {
            BedRoomRoomType RoomType = new BedRoomRoomType
            {
                BedRoomRoomTypeStatusId = (int)BedRoomRoomTypeStatusEnum.Active,
                Name = createBedRoomRoomType.Request.Name,
                //BedRoomId = createBedRoomRoomType.Request.BedRoomId
            };

            await _context.AddAsync(RoomType);
            await _context.SaveChangesAsync();

            var response = new CreateBedRoomRoomTypeResponse
            {
                Name = RoomType.Name,
                //BedRoomId = RoomType.BedRoomId
            };

            return ApiResult<CreateBedRoomRoomTypeResponse>.OK(response);
        }


        public async Task<ApiResult<DeleteBedRoomRoomTypeResponse>> DeleteBedRoomRoomType(int BedRoomRoomTypeId)
        {
            var roomType = await _context.BedRoomRoomTypes.Where(x => x.Id == BedRoomRoomTypeId).FirstOrDefaultAsync();
            

            roomType.BedRoomRoomTypeStatusId = (int)BedRoomRoomTypeStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            var response = new DeleteBedRoomRoomTypeResponse
            {
                Name = roomType.Name,
            };

            return ApiResult<DeleteBedRoomRoomTypeResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetBedRoomRoomTypeResponse>>> GetBedRoomRoomType(GetBedRoomRoomTypeRequest request)
        {

            var roomtype = await _context.BedRoomRoomTypes.Where(x => x.BedRoomRoomTypeStatusId == (int)BedRoomRoomTypeStatusEnum.Active && (request.Id != null ? x.Id == request.Id : true)).Select(x => new GetBedRoomRoomTypeResponse
            {
                Id = x.Id,
                //BedRoomId = x.BedRoomId,
                Name = x.Name,
                BedRoomRoomTypeStatusId = x.BedRoomRoomTypeStatusId,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                //BedRoomName = x.BedRoom.Name,

            }).ToListAsync();

            return ApiResult<List<GetBedRoomRoomTypeResponse>>.OK(roomtype);
        }

        public async Task<ApiResult<GetBedRoomRoomTypeByIdResponse>> GetBedRoomRoomTypeById(int BedRoomRoomTypeId)
        {
            var roomtype = await _context.BedRoomRoomTypes.Where(x => x.Id == BedRoomRoomTypeId).Select(x => new GetBedRoomRoomTypeByIdResponse
            {
                Name = x.Name,
                BedRoomRoomTypeStatusId = x.BedRoomRoomTypeStatusId

            }).FirstOrDefaultAsync();

            return ApiResult<GetBedRoomRoomTypeByIdResponse>.OK(roomtype);

        }

        public async Task<ApiResult<UpdateBedRoomRoomTypeResponse>> UpdateBedRoomRoomType(UpdateBedRoomRoomTypeCommand updateBedRoomRoomType, int BedRoomRoomTypeId)
        {
            var result = await _context.BedRoomRoomTypes.Where(x => x.Id == BedRoomRoomTypeId).FirstOrDefaultAsync();
            result.Name = updateBedRoomRoomType.Request.Name;
            //result.BedRoomId = updateBedRoomRoomType.Request.BedRoomId;

            await _context.SaveChangesAsync();

            var roomtype = new UpdateBedRoomRoomTypeResponse
            {
                Name = result.Name,
                //BedRoomId = result.BedRoomId,
            };

            return ApiResult<UpdateBedRoomRoomTypeResponse>.OK(roomtype);
        }
    }
}
