using EEWF.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomRoom.CreateCity;
using UniveristyLifeApp.Models.v1.BedRoomRoom.DeleteBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoom;
using UniveristyLifeApp.Models.v1.BedRoomRoom.GetBedRoomRoomById;
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
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        public BedRoomRoomService(ApplicationContext context , IWebHostEnvironment env, IFileService fileService)
        {
            _context = context;
            _env = env;
            _fileService = fileService;
        }

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

            int count = 1;

            if(request.Request.ImageFile != null)
            {
                foreach (var item in request.Request.ImageFile)
                {
                    BedRoomRoomPhoto photos = new BedRoomRoomPhoto
                    {
                        BedRoomRoomId = bedRoomRoom.Id,
                        IsActive = true,
                    };

                    if(count == 1)
                    {
                        photos.IsMain = true;
                    }

                    if (_env.WebRootPath.Contains("MVC"))
                    {
                        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                        photos.Name = await _fileService.SaveImage(path2, "uploads/bedRoomRoomPhotos", item);
                    }

                    else
                    {
                        photos.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedRoomRoomPhotos", item);
                    }
                    count++;
                    await _context.BedRoomRoomPhotos.AddAsync(photos);
                }

                await _context.SaveChangesAsync();
            }

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
            var bedRoomRooms = await _context.BedRoomRooms.Include(x => x.BedRoom).Include(x => x.BedRoomRoomPhotos).Where(x => x.BedRoomRoomStatusId == (int)BedRoomRoomStatusEnum.Active && (request.BedRoomRoomId != null ? x.Id == request.BedRoomRoomId : true) && (request.BedRoomRoomTypeId != null ? x.BedRoomRoomTypeId == request.BedRoomRoomTypeId : true)).Select(x => new GetBedRoomRoomResponse
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                BedRoomId= x.BedRoomId,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                BedRoomRoomTypeId = x.BedRoomRoomTypeId,
                Image = x.BedRoomRoomPhotos.Select(x => "http://highresultech-001-site1.ftempurl.com/uploads/bedRoomRoomPhotos/" + x.Name).ToList(),
            }).ToListAsync();

            return ApiResult<List<GetBedRoomRoomResponse>>.OK(bedRoomRooms);
        }

        public async Task<ApiResult<GetBedRoomRoomByIdResponse>> GetBedRoomRoomById(int bedRoomRoomId)
        {
            var bedroomroom = await _context.BedRoomRooms.Where(x => x.Id == bedRoomRoomId).FirstOrDefaultAsync();

            GetBedRoomRoomByIdResponse response = new GetBedRoomRoomByIdResponse
            {
                Id = bedroomroom.Id,
                BedRoomId = bedroomroom.BedRoomId,
                BedRoomRoomTypeId = bedroomroom.BedRoomRoomTypeId,
                CreateAt= bedroomroom.CreateAt,
                Description = bedroomroom.Description,
                Name = bedroomroom.Name,
                Price= bedroomroom.Price,
                UpdateAt = bedroomroom.UpdateAt
            };

            return ApiResult<GetBedRoomRoomByIdResponse>.OK(response);
        }

        public async Task<ApiResult<UpdateBedRoomRoomResponse>> UpdateBedRoomRoom(UpdateBedRoomRoomCommand request, int bedRoomRoomId)
        {
            var bedRoomRoom = await _context.BedRoomRooms.Where(x => x.Id == bedRoomRoomId).FirstOrDefaultAsync();
            var bedRoomRoomPhotos = await _context.BedRoomRoomPhotos.Where(x => x.BedRoomRoomId == bedRoomRoomId).ToListAsync();

            bedRoomRoom.Name = request.Request.Name;
            bedRoomRoom.Description = request.Request.Description;
            bedRoomRoom.BedRoomId = request.Request.BedRoomId;
            bedRoomRoom.BedRoomRoomTypeId = request.Request.BedRoomRoomTypeId;
            bedRoomRoom.Price = request.Request.Price;

            if(request.Request.ImageFile != null)
            {
                foreach (var item in bedRoomRoomPhotos)
                {
                    if (_env.WebRootPath.Contains("MVC"))
                    {
                        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                        _fileService.DeleteImage(path2, "uploads/bedRoomRoomPhotos", item.Name);
                    }

                    else
                    {
                        _fileService.DeleteImage(_env.WebRootPath, "uploads/bedRoomRoomPhotos", item.Name);
                    }
                }

                int count = 1;

                foreach (var item in request.Request.ImageFile)
                {
                    BedRoomRoomPhoto photos = new BedRoomRoomPhoto
                    {
                        BedRoomRoomId = bedRoomRoom.Id,
                        IsActive = true,
                    };

                    if(count == 1)
                    {
                        photos.IsMain = true;
                    }

                    if (_env.WebRootPath.Contains("MVC"))
                    {
                        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");

                        photos.Name = await _fileService.SaveImage(path2, "uploads/bedRoomRoomPhotos", item);
                    }

                    else
                    {
                        photos.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedRoomRoomPhotos", item);
                    }

                    count++;

                    await _context.BedRoomRoomPhotos.AddAsync(photos);
                }

            }

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
