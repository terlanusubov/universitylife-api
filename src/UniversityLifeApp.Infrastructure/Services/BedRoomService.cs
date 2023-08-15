using Azure.Core;
using EEWF.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.CreateBedRoom;
using UniversityLifeApp.Application.CQRS.v1.BedRoom.Commands.UpdateBedRoom;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomService : IBedRoomService
    {
        private readonly ApplicationContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public BedRoomService(ApplicationContext context, IFileService fileService, IWebHostEnvironment env)
        {
            _context = context;
            _fileService = fileService;
            _env = env;
        }

        public async Task<ApiResult<CreateBedRoomResponse>> CreateBedRoom(CreateBedRoomCommand createBedRoom)
        {
            BedRoom bedRoom = new BedRoom
            {
                Description = createBedRoom.Request.Description,
                DistanceToCenter = createBedRoom.Request.DistanceToCenter,
                Latitude = createBedRoom.Request.Latitude,
                Longitude = createBedRoom.Request.Longitude,
                Name = createBedRoom.Request.Name,
                Rating = createBedRoom.Request.Rating,
                CityId = createBedRoom.Request.CityId,
                BedRoomStatusId = (int)BedRoomStatusEnum.Active,
            };

            await _context.AddAsync(bedRoom);
            await _context.SaveChangesAsync();

            BedRoomPhoto bedRoomPhoto = new BedRoomPhoto()
            {
                BedroomId = bedRoom.Id,
                IsMain = createBedRoom.Request.IsMain,
                IsActive = createBedRoom.Request.IsActive,
            };
            foreach (var item in createBedRoom.Request.ImageFile)
            {
                bedRoomPhoto.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedroomPhoto", item);

                await _context.BedRoomPhotos.AddAsync(bedRoomPhoto);
            }
                await _context.SaveChangesAsync();

            var response = new CreateBedRoomResponse
            {
                Name = bedRoom.Name,
                CityId = bedRoom.CityId,
                Description = bedRoom.Description,
                DistanceToCenter = bedRoom.DistanceToCenter,
                Latitude = bedRoom.Latitude,
                Longitude = bedRoom.Longitude,
                Rating = bedRoom.Rating,
                Image = bedRoomPhoto.Name,
                IsMain = bedRoomPhoto.IsMain,
                IsActive = bedRoomPhoto.IsActive,
            };

            return ApiResult<CreateBedRoomResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteBedRoomResponse>> DeleteBedRoom(int bedroomId)
        {
            var bedroom = await _context.BedRooms.Where(x => x.Id == bedroomId).FirstOrDefaultAsync();
            bedroom.BedRoomStatusId = (int)BedRoomStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            var response = new DeleteBedRoomResponse
            {
                BedRoomId = bedroomId,
            };

            return ApiResult<DeleteBedRoomResponse>.OK(response);

            throw new NotImplementedException();
        }

        public async Task<ApiResult<List<GetBedRoomResponse>>> GetBedRoom()
        {
            var bedRooms = await _context.BedRooms.Select(x => new GetBedRoomResponse
            {
                Name = x.Name,
                BedRoomStatusId = x.BedRoomStatusId,
                Description = x.Description,
                DistanceToCenter = x.DistanceToCenter,
                CityId = x.CityId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Rating = x.Rating,

            }).ToListAsync();

            return ApiResult<List<GetBedRoomResponse>>.OK(bedRooms);

        }

        public async Task<ApiResult<GetBedRoomByIdResponse>> GetBedRoomById(int bedroomId)
        {
            var bedroom = await _context.BedRooms.Where(x => x.Id == bedroomId).Select(x => new GetBedRoomByIdResponse
            {
                Name = x.Name,
                BedRoomStatusId = x.BedRoomStatusId,
                Description = x.Description,
                DistanceToCenter = x.DistanceToCenter,
                CityId = x.CityId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Rating = x.Rating,

            }).FirstOrDefaultAsync();



            return ApiResult<GetBedRoomByIdResponse>.OK(bedroom);
        }

        public async Task<ApiResult<UpdateBedRoomResponse>> UpdateBedRoom(UpdateBedRoomCommand updateBedRoom, int bedroomId)
        {
            var result = await _context.BedRooms.Where(x => x.Id == bedroomId).FirstOrDefaultAsync();

            result.Longitude = updateBedRoom.Request.Longitude;
            result.Latitude = updateBedRoom.Request.Latitude;
            result.Rating = updateBedRoom.Request.Rating;
            result.Description = updateBedRoom.Request.Description;
            result.CityId = updateBedRoom.Request.CityId;
            result.Name = updateBedRoom.Request.Name;
            result.DistanceToCenter = updateBedRoom.Request.DistanceToCenter;

            await _context.SaveChangesAsync();

            var bedroom = new UpdateBedRoomResponse
            {
                Description = result.Description,
                CityId = result.CityId,
                Latitude = result.Latitude,
                Longitude = result.Longitude,
                Rating = result.Rating,
                Name = result.Name,
                DistanceToCenter = result.DistanceToCenter,
            };

            return ApiResult<UpdateBedRoomResponse>.OK(bedroom);
        }
    }
}
