using Azure.Core;
using EEWF.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.CreateBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.DeleteBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoomById;
using UniveristyLifeApp.Models.v1.BedRoom.UpdateBedRoom;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniveristyLifeApp.Models.v1.DeleteFile;
using UniveristyLifeApp.Models.v1.Upload;
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
        private readonly IWebHostEnvironment _env;
        private readonly IFileService _fileService;
        private readonly IConfiguration _configuration;
        public BedRoomService(ApplicationContext context, IWebHostEnvironment env, IFileService fileService, IConfiguration configuration)
        {
            _context = context;
            _env = env;
            _fileService = fileService;
            _configuration = configuration;
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

            foreach (var item in createBedRoom.Request.ImageFile)
            {
                string filename = item.FileName;
                filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
                filename = Guid.NewGuid().ToString() + filename;


                UploadDto dto = new UploadDto
                {
                    File = item,
                    FileName = filename,
                };
                List<UploadDto> uploadDtos = new List<UploadDto>();
                uploadDtos.Add(dto);

                UploadRequest uploadRequest = new UploadRequest
                {
                    UploadDto = uploadDtos,
                    Folder = "uploads/bedroomPhoto",
                };

                using (HttpClient client = new HttpClient())
                {

                    //var multipartContent = new MultipartFormDataContent();
                    client.BaseAddress = new Uri("https://api.universitylife.co.uk/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                    int index = 0;
                    foreach (var uploadDto in uploadRequest.UploadDto)
                    {
                        var multipartContent = new MultipartFormDataContent();

                        var fileContent = new StreamContent(uploadDto.File.OpenReadStream());
                        fileContent.Headers.ContentType = new MediaTypeHeaderValue(uploadDto.File.ContentType);

                        multipartContent.Add(fileContent, "UploadDto[" + index + "].File", uploadDto.File.FileName);

                        var filenameContent = new StringContent(uploadDto.FileName);
                        multipartContent.Add(filenameContent, "UploadDto[" + index + "].FileName");

                        multipartContent.Add(new StringContent(uploadRequest.Folder), "Folder");

                        var resultFile = await client.PostAsync("api/v1/file/upload", multipartContent);
                        Console.WriteLine($"___________________________________{resultFile}_____________________");

                        index++;
                    }

                }

                var photo = new BedRoomPhoto
                {
                    Name = filename,
                    IsMain = false,
                    IsActive = true,
                    BedroomId = bedRoom.Id
                };

                if (count == 1)
                    photo.IsMain = true;

                count++;

                await _context.BedRoomPhotos.AddAsync(photo);

            }

            await _context.SaveChangesAsync();


            //if (createBedRoom.Request.ImageFile != null)
            //{
            //    foreach (var item in createBedRoom.Request.ImageFile)
            //    {
            //        BedRoomPhoto photo = new BedRoomPhoto
            //        {
            //            BedroomId = bedRoom.Id,
            //            IsActive = true,
            //        };

            //        if (count == 1)
            //        {
            //            photo.IsMain = true;
            //        }


            //        if (_env.WebRootPath.Contains("MVC"))
            //        {
            //            var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
            //            var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
            //            photo.Name = await _fileService.SaveImage(path2, "uploads/bedroomPhoto", item);
            //        }

            //        else
            //        {
            //            photo.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedroomPhoto", item);
            //        }
            //        count++;
            //        await _context.BedRoomPhotos.AddAsync(photo);

            //    }
            //}

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

        }

        public async Task<ApiResult<GetBedRoomResponse>> GetBedRoom(GetBedRoomRequest request)
        {
            //var bedRooms2 = await _context.BedRooms.Where(x => x.BedRoomStatusId == (int)BedRoomStatusEnum.Active && (request.CityId != null ? x.CityId == request.CityId : true)).ToListAsync();
            var baseUrl = _configuration["BaseUrl"];
            var query = _context.BedRooms.Include(x=>x.City).Where(x => x.BedRoomStatusId == (int)BedRoomStatusEnum.Active && (request.CityId != null ? x.CityId == request.CityId : true)).Select(x => new GetBedRoomsDto
            {
                Id = x.Id,
                Name = x.Name,
                BedRoomStatusId = x.BedRoomStatusId,
                Description = x.Description,
                DistanceToCenter = x.DistanceToCenter,
                //CityId = x.CityId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Rating = x.Rating,
                BedRoomRoomTypeIds = x.RoomTypes.Select(x => x.BedRoomRoomTypeId).ToList(),
                BedRoomRoomTypes = x.RoomTypes.Select(c => c.BedRoomRoomType.Name).ToList(),
                Price = x.Price,
                BedRoomImages = x.BedRoomPhotos.Select(c => baseUrl + "bedroomPhoto/" + c.Name).ToList(),
            });
            var response = new GetBedRoomResponse();
            List<double> distances = new List<double>();
            List<IDictionary<int, double>> responseList = new();

            if (request.UniversityId != null)
            {
                var geUniCityId = await _context.Universities.Where(x => x.Id == request.UniversityId).Select(x => x.CityId).FirstOrDefaultAsync();
                int cityId = geUniCityId;
                var uniLongitude = await _context.Universities.Where(x => x.Id == request.UniversityId).Select(x => x.Longitude).FirstOrDefaultAsync();
                double lon = Convert.ToDouble(uniLongitude);
                var uniLatitude = await _context.Universities.Where(x => x.Id == request.UniversityId).Select(x => x.Latitude).FirstOrDefaultAsync();
                double lat = Convert.ToDouble(uniLatitude);
                var getBedroomByCity = await _context.BedRooms.Where(x => x.CityId == cityId && x.BedRoomStatusId == (int)BedRoomStatusEnum.Active && (request.CityId != null ? x.CityId == request.CityId : true)).ToListAsync();
                query = _context.BedRooms.Include(x => x.City).Include(x => x.RoomTypes).Where(x => x.BedRoomStatusId == (int)BedRoomStatusEnum.Active && x.CityId == cityId && (request.CityId != null ? x.CityId == request.CityId : true)).Select(x => new GetBedRoomsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    BedRoomStatusId = x.BedRoomStatusId,
                    Description = x.Description,
                    DistanceToCenter = x.DistanceToCenter,
                    //CityId = x.CityId,
                    Latitude = x.Latitude,
                    Longitude = x.Longitude,
                    CreateAt = x.CreateAt,
                    UpdateAt = x.UpdateAt,
                    Rating = x.Rating,
                    BedRoomRoomTypeIds = x.RoomTypes.Select(x => x.BedRoomRoomTypeId).ToList(),
                    BedRoomRoomTypes = x.RoomTypes.Select(c => c.BedRoomRoomType.Name).ToList(),
                    Price = x.Price,
                    BedRoomImages = x.BedRoomPhotos.Select(c => @"http://highresultech-001-site1.ftempurl.com/uploads/bedroomPhoto/" + c.Name).ToList(),
                });

                for (int i = 0; i < getBedroomByCity.Count; i++)
                {
                    const double radius = 6371;
                    double lat2 = Convert.ToDouble(query.ToList()[i].Latitude);
                    double lon2 = Convert.ToDouble(query.ToList()[i].Longitude);

                    double radLat1 = ToRadians(lat);
                    double radLon1 = ToRadians(lon);
                    double radLat2 = ToRadians(lat2);
                    double radLon2 = ToRadians(lon2);

                    double dLon = radLon2 - radLon1;
                    double dLat = radLat2 - radLat1;

                    double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                               Math.Cos(radLat1) * Math.Cos(radLat2) *
                               Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                    double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                    double distance = radius * c;
                    distances.Add(distance);
                    IDictionary<int, double> map = new Dictionary<int, double>();
                    map.Add(query.ToList()[i].Id, distance);
                    responseList.Add(map);
                    response.Dictance = responseList;
                }
                static double ToRadians(double degree)
                {
                    return degree * (Math.PI / 180);
                }

                //bedRooms2 = query.ToList();
            }





            var totalData = query.ToList().Count();

            var pageSize = 6;


            var totalPage = totalData % pageSize != 0 ? (totalData / pageSize) + 1 : totalData / pageSize;

            int? start;
            int? end;


            if (request.Page != null)
            {
                start = (request.Page - 1) * 6 + 1;
                end = start + 5;

                if (start != null)
                {
                    query = query.Skip(start.Value - 1).Take(end.Value);

                }
            }





            var bedRooms = await query.OrderByDescending(x => x.CreateAt).ToListAsync();


            response.BedRooms = bedRooms;

            response.TotalData = totalData;
            response.PageSize = pageSize;
            response.TotalPage = totalPage;
            response.Dictance = responseList;
            return ApiResult<GetBedRoomResponse>.OK(response);
        }

        public async Task<ApiResult<GetBedRoomByIdResponse>> GetBedRoomById(int bedroomId)
        {
            var bedroom = await _context.BedRooms.Where(x => x.Id == bedroomId).Select(x => new GetBedRoomByIdResponse
            {


                Id = x.Id,
                Name = x.Name,
                BedRoomStatusId = x.BedRoomStatusId,
                Description = x.Description,
                DistanceToCenter = x.DistanceToCenter,
                //CityId = x.CityId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Rating = x.Rating,
                BedRoomRoomTypeIds = x.RoomTypes.Select(x => x.BedRoomRoomTypeId).ToList(),
                BedRoomRoomTypes = x.RoomTypes.Select(c => c.BedRoomRoomType.Name).ToList(),
                Price = x.Price,
                BedRoomImages = x.BedRoomPhotos.Select(c => @"http://highresultech-001-site1.ftempurl.com/uploads/bedroomPhoto/" + c.Name).ToList(),


                //Name = x.Name,
                //BedRoomStatusId = x.BedRoomStatusId,
                //Description = x.Description,
                //DistanceToCenter = x.DistanceToCenter,
                //CityId = x.CityId,
                //Latitude = x.Latitude,
                //Longitude = x.Longitude,
                //Rating = x.Rating,
                //Price = x.Price,
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
                foreach (var image in bedRoomPhotos)
                {
                    DeleteDto dto = new DeleteDto
                    {
                        FileName = image.Name,
                    };
                    List<DeleteDto> deleteDtos = new List<DeleteDto>();
                    deleteDtos.Add(dto);

                    DeleteRequest deleteRequest = new DeleteRequest
                    {
                        DeleteDto = deleteDtos,
                        Folder = "uploads/bedroomPhoto",
                    };

                    using (HttpClient client = new HttpClient())
                    {

                        client.BaseAddress = new Uri("https://api.universitylife.co.uk/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                        int index = 0;
                        foreach (var uploadDto in deleteRequest.DeleteDto)
                        {
                            var multipartContent = new MultipartFormDataContent();

                            //var fileContent = new StreamContent(uploadDto.File.OpenReadStream());
                            //fileContent.Headers.ContentType = new MediaTypeHeaderValue(uploadDto.File.ContentType);

                            //multipartContent.Add(fileContent, "UploadDto[" + index + "].File", uploadDto.File.FileName);

                            var filenameContent = new StringContent(uploadDto.FileName);
                            multipartContent.Add(filenameContent, "DeleteDto[" + index + "].FileName");

                            multipartContent.Add(new StringContent(deleteRequest.Folder), "Folder");

                            var resultFile = await client.PostAsync("api/v1/file/delete", multipartContent);

                            index++;
                        }



                    }

                    _context.BedRoomPhotos.Remove(image);
                }

                await _context.SaveChangesAsync();

                int count = 0;

                foreach (var item in updateBedRoom.Request.ImageFile)
                {
                    string filename = item.FileName;
                    filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
                    filename = Guid.NewGuid().ToString() + filename;


                    UploadDto dto = new UploadDto
                    {
                        File = item,
                        FileName = filename,
                    };
                    List<UploadDto> uploadDtos = new List<UploadDto>();
                    uploadDtos.Add(dto);

                    UploadRequest uploadRequest = new UploadRequest
                    {
                        UploadDto = uploadDtos,
                        Folder = "uploads/bedroomPhoto",
                    };

                    using (HttpClient client = new HttpClient())
                    {

                        //var multipartContent = new MultipartFormDataContent();
                        client.BaseAddress = new Uri("https://api.universitylife.co.uk/");
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                        int index = 0;
                        foreach (var uploadDto in uploadRequest.UploadDto)
                        {
                            var multipartContent = new MultipartFormDataContent();

                            var fileContent = new StreamContent(uploadDto.File.OpenReadStream());
                            fileContent.Headers.ContentType = new MediaTypeHeaderValue(uploadDto.File.ContentType);

                            multipartContent.Add(fileContent, "UploadDto[" + index + "].File", uploadDto.File.FileName);

                            var filenameContent = new StringContent(uploadDto.FileName);
                            multipartContent.Add(filenameContent, "UploadDto[" + index + "].FileName");

                            multipartContent.Add(new StringContent(uploadRequest.Folder), "Folder");

                            var resultFile = await client.PostAsync("api/v1/file/upload", multipartContent);
                            Console.WriteLine($"___________________________________{resultFile}_____________________");

                            index++;
                        }

                    }

                    var photo = new BedRoomPhoto
                    {
                        Name = filename,
                        IsMain = false,
                        IsActive = true,
                        BedroomId = result.Id
                    };

                    if (count == 1)
                        photo.IsMain = true;

                    count++;

                    await _context.BedRoomPhotos.AddAsync(photo);

                }

                await _context.SaveChangesAsync();
            }

            //if (updateBedRoom.Request.ImageFile != null)
            //{
            //    foreach (var item in bedRoomPhotos)
            //    {
            //        if (_env.WebRootPath.Contains("MVC"))
            //        {
            //            var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
            //            var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
            //            _fileService.DeleteImage(path2, "uploads/bedroomPhoto", item.Name);
            //        }

            //        else
            //        {
            //            _fileService.DeleteImage(_env.WebRootPath, "uploads/bedroomPhoto", item.Name);
            //        }

            //        _context.BedRoomPhotos.Remove(item);
            //    }

            //    int count = 1;

            //    foreach (var item in updateBedRoom.Request.ImageFile)
            //    {
            //        BedRoomPhoto photo = new BedRoomPhoto
            //        {
            //            BedroomId = result.Id,
            //            IsActive = true,
            //        };

            //        if (count == 1)
            //        {
            //            photo.IsMain = true;
            //        }


            //        if (_env.WebRootPath.Contains("MVC"))
            //        {
            //            var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
            //            var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
            //            photo.Name = await _fileService.SaveImage(path2, "uploads/bedroomPhoto", item);
            //        }

            //        else
            //        {
            //            photo.Name = await _fileService.SaveImage(_env.WebRootPath, "uploads/bedroomPhoto", item);
            //        }
            //        count++;
            //        await _context.BedRoomPhotos.AddAsync(photo);

            //    }
            //}



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
