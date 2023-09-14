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
using UniversityLifeApp.Infrastructure.Migrations;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomService : IBedRoomService
    {
        private readonly ApplicationContext _context;
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        public BedRoomService(ApplicationContext context, IWebHostEnvironment env, IFileService fileService)
        {
            _context = context;
            _env = env;
            _fileService = fileService;
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
                Price = createBedRoom.Request.Price,
                BedRoomStatusId = (int)BedRoomStatusEnum.Active,
            };

            await _context.AddAsync(bedRoom);
            await _context.SaveChangesAsync();
            int count = 1;

            if(createBedRoom.Request.ImageFile != null)
            {
                foreach (var item in createBedRoom.Request.ImageFile)
                {
                    BedRoomPhoto photo = new BedRoomPhoto
                    {
                        BedroomId = bedRoom.Id,
                        IsActive = true,
                    };

                    if(count == 1)
                    {
                        photo.IsMain = true;
                    }

                   
                        if (_env.WebRootPath.Contains("MVC"))
                        {
                            var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                            var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                            photo.Name = await _fileService.SaveImage(path2, "uploads/bedroomPhoto", item);
                        }

                        else
                        {
                            photo.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedroomPhoto", item);
                        }
                        count++;
                        await _context.BedRoomPhotos.AddAsync(photo);
                        
                }
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

                Price = bedRoom.Price,

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

        public async Task<ApiResult<GetBedRoomResponse>> GetBedRoom(GetBedRoomRequest request)
        {
            var bedRooms2 = await _context.BedRooms.ToListAsync();

            var totalData = bedRooms2.Count();

            var pageSize = 6;


            var totalPage = totalData % pageSize != 0 ? (totalData / pageSize) + 1 : totalData / pageSize;

            int? start;
            int? end;
                
            var query = _context.BedRooms.Where(x => x.BedRoomStatusId == (int)BedRoomStatusEnum.Active && request.CityId != null ? x.CityId == request.CityId : request.CityId == null).Select(x => new GetBedRoomsDto
            {
                Name = x.Name,
                BedRoomStatusId = x.BedRoomStatusId,
                Description = x.Description,
                DistanceToCenter = x.DistanceToCenter,
                CityId = x.CityId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Rating = x.Rating,
                BedRoomRoomTypes = x.BedRoomRoomTypes.Select(c => c.Name).ToList(),
                Price = x.Price,
                BedRoomImages = x.BedRoomPhotos.Select(c => @"http://highresultech-001-site1.ftempurl.com/uploads/bedroomPhoto/" + c.Name).ToList(),

            });

            if (request.Page != null)
            {
                start = (request.Page - 1) * 6 + 1;
                end = start + 5;

                if (start != null)
                {
                    query = query.Skip(start.Value - 1).Take(end.Value);

                }
            }

            var bedRooms = await query.ToListAsync();

            var response = new GetBedRoomResponse();

            response.BedRooms = bedRooms;

            response.TotalData = totalData;
            response.PageSize = pageSize;
            response.TotalPage = totalPage;
            return ApiResult<GetBedRoomResponse>.OK(response);

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
                Price = x.Price,
            }).FirstOrDefaultAsync();



            return ApiResult<GetBedRoomByIdResponse>.OK(bedroom);
        }

        public async Task<ApiResult<UpdateBedRoomResponse>> UpdateBedRoom(UpdateBedRoomCommand updateBedRoom, int bedroomId)
        {
            var result = await _context.BedRooms.Where(x => x.Id == bedroomId).FirstOrDefaultAsync();
            var bedRoomPhotos = await _context.BedRoomPhotos.Where(x => x.BedroomId == bedroomId).ToListAsync();

            result.Longitude = updateBedRoom.Request.Longitude;
            result.Latitude = updateBedRoom.Request.Latitude;
            result.Rating = updateBedRoom.Request.Rating;
            result.Description = updateBedRoom.Request.Description;
            result.CityId = updateBedRoom.Request.CityId;
            result.Name = updateBedRoom.Request.Name;
            result.DistanceToCenter = updateBedRoom.Request.DistanceToCenter;
            result.Price = updateBedRoom.Request.Price;

            if(updateBedRoom.Request.ImageFile != null)
            {
                foreach (var item in bedRoomPhotos)
                {
                    if (_env.WebRootPath.Contains("MVC"))
                    {
                        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                        _fileService.DeleteImage(path2, "uploads/bedroomPhoto", item.Name);
                    }

                    else
                    {
                        _fileService.DeleteImage(_env.WebRootPath, "uploads/bedroomPhoto", item.Name);
                    }

                    _context.BedRoomPhotos.Remove(item);
                }

                int count = 1;

                foreach (var item in updateBedRoom.Request.ImageFile)
                {
                    BedRoomPhoto photo = new BedRoomPhoto
                    {
                        BedroomId = result.Id,
                        IsActive = true,
                    };

                    if (count == 1)
                    {
                        photo.IsMain = true;
                    }


                    if (_env.WebRootPath.Contains("MVC"))
                    {
                        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                        photo.Name = await _fileService.SaveImage(path2, "uploads/bedroomPhoto", item);
                    }

                    else
                    {
                        photo.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedroomPhoto", item);
                    }
                    count++;
                    await _context.BedRoomPhotos.AddAsync(photo);

                }
            }



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
                Price = result.Price,
            };

            return ApiResult<UpdateBedRoomResponse>.OK(bedroom);
        }
    }
}
