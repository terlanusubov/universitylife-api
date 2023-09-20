using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.RoomType.CreateRoomType;
using UniveristyLifeApp.Models.v1.RoomType.GetRoomType;
using UniveristyLifeApp.Models.v1.RoomType.UpdateRoomType;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly ApplicationContext _context;
        public RoomTypeService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ApiResult<CreateRoomTypeResponse>> Create(CreateRoomTypeRequest request)
        {
            RoomType type = new RoomType
            {
                Name = request.Name
            };

            await _context.AddAsync(type);
            await _context.SaveChangesAsync();

            var response = new CreateRoomTypeResponse
            {
                Name = type.Name,
            };

            return ApiResult<CreateRoomTypeResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetRoomTypeResponse>>> Get()
        {
            var types = await _context.RoomTypes.Select(x => new GetRoomTypeResponse
            {
                Name = x.Name,
            }).ToListAsync();

            return ApiResult<List<GetRoomTypeResponse>>.OK(types);
        }

        public async Task<ApiResult<UpdateRoomTypeResponse>> Update(UpdateRoomTypeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
