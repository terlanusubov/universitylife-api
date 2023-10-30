using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
using UniveristyLifeApp.Models.v1.DeleteFile;
using UniveristyLifeApp.Models.v1.Upload;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.AddCity;
using UniversityLifeApp.Application.CQRS.v1.Cities.Commands.UpdateCity;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;
        public CityService(ApplicationContext context, IWebHostEnvironment env, IFileService fileService, IConfiguration configuration)
        {
            _context = context;
            _fileService = fileService;
            _env = env;
            _configuration = configuration; ;
        }


        public async Task<ApiResult<AddCityResponse>> AddCity(AddCityCommand request)
        {
            City city = new City
            {
                Name = request.Request.Name,
                CityStatusId = (int)CityStatusEnum.Active,
                CountryId = request.Request.CountryId,
                Latitude = request.Request.Latitude,
                Longitude = request.Request.Longitude,
                IsTop = request.Request.IsTop,
            };
            string filename = request.Request.ImageFile.FileName;
            filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
            filename = Guid.NewGuid().ToString() + filename;


            UploadDto dto = new UploadDto
            {
                File = request.Request.ImageFile,
                FileName = filename,
            };
            List<UploadDto> uploadDtos = new List<UploadDto>();
            uploadDtos.Add(dto);

            UploadRequest uploadRequest = new UploadRequest
            {
                UploadDto = uploadDtos,
                Folder = "uploads/city",
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

            city.Image = filename;





            //if (_env.WebRootPath.Contains("MVC"))
            //{
            //    var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
            //    var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
            //    city.Image = await _fileService.SaveImage(path2, "uploads/city", request.Request.ImageFile);
            //}
            //else
            //{
            //    city.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/city", request.Request.ImageFile);
            //}



            await _context.Cities.AddAsync(city);
            await _context.SaveChangesAsync();

            var response = new AddCityResponse
            {
                Name = city.Name,
                CountryId = city.CountryId,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                CityStatusId = city.CityStatusId,
                IsTop = city.IsTop,
                Image = city.Image,
            };

            return ApiResult<AddCityResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteCityResponse>> DeleteCity(int cityId)
        {
            var city = await _context.Cities.Where(x => x.Id == cityId).FirstOrDefaultAsync();



            city.CityStatusId = (int)CityStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            var response = new DeleteCityResponse
            {
                CityId = city.Id,
            };

            return ApiResult<DeleteCityResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetCityResponse>>> GetCity(GetCityRequest request)
        {



            var baseUrl = _configuration["BaseUrl"];
            var cities = await _context.Cities.Include(x => x.Country).Where(x => x.CityStatusId == (int)CityStatusEnum.Active && (request.IsTop != null ? x.IsTop == request.IsTop : true) && (request.CountryId != null ? x.CountryId == request.CountryId : true)).Select(x => new GetCityResponse

            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CountryId = x.CountryId,
                BedRoomCount = x.BedRooms.Count(),
                IsTop = x.IsTop,
                Image = baseUrl + "city/" + x.Image,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                CountryName = x.Country.Name,
            }).OrderByDescending(x => x.CreateAt).ToListAsync();

            return ApiResult<List<GetCityResponse>>.OK(cities);
        }

        public async Task<ApiResult<GetCityByIdResponse>> GetCityById(int cityId)
        {
            var city = await _context.Cities.Where(x => x.Id == cityId && x.CityStatusId == (int)CityStatusEnum.Active).Select(x => new GetCityByIdResponse
            {
                Name = x.Name,
                CountryId = x.CountryId,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                Image = x.Image,
            }).FirstOrDefaultAsync();

            return ApiResult<GetCityByIdResponse>.OK(city);
        }

        public async Task<ApiResult<UpdateCityResponse>> UpdateCity(UpdateCityCommand request, int cityId)
        {
            var city = await _context.Cities.Where(x => x.Id == cityId).FirstOrDefaultAsync();

            city.Name = request.Request.Name;
            city.Latitude = request.Request.Latitude;
            city.Longitude = request.Request.Longitude;
            city.CountryId = request.Request.CountryId;
            city.IsTop = request.Request.IsTop;

            if(request.Request.ImageFile != null)
            {
                DeleteDto dto = new DeleteDto
                {
                    FileName = city.Image,
                };
                List<DeleteDto> deleteDtos = new List<DeleteDto>();
                deleteDtos.Add(dto);

                DeleteRequest deleteRequest = new DeleteRequest
                {
                    DeleteDto = deleteDtos,
                    Folder = "uploads/city",
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
            }
            
            string filename = request.Request.ImageFile.FileName;
            filename = filename.Length <= 64 ? filename : (filename.Substring(filename.Length - 64, 64));
            filename = Guid.NewGuid().ToString() + filename;


            UploadDto uDto = new UploadDto
            {
                File = request.Request.ImageFile,
                FileName = filename,
            };
            List<UploadDto> uploadDtos = new List<UploadDto>();
            uploadDtos.Add(uDto);

            UploadRequest uploadRequest = new UploadRequest
            {
                UploadDto = uploadDtos,
                Folder = "uploads/city",
            };

            using (HttpClient client = new HttpClient())
            {

                //var multipartContent = new MultipartFormDataContent();
                client.BaseAddress = new Uri("http://localhost:5212/");
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

            city.Image = filename;

            //if (request.Request.ImageFile != null)
            //{
            //    if (_env.WebRootPath.Contains("MVC"))
            //    {
            //        var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
            //        var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
            //        _fileService.DeleteImage(path2, "uploads/city", city.Image);
            //        city.Image = await _fileService.SaveImage(path2, "uploads/city", request.Request.ImageFile);
            //    }
            //    else
            //    {
            //        _fileService.DeleteImage(_env.WebRootPath, "uploads/city", city.Image);
            //        city.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/city", request.Request.ImageFile);

            //    }

            //}

            await _context.SaveChangesAsync();

            var response = new UpdateCityResponse
            {
                Name = city.Name,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                CountryId = city.CountryId,
                IsTop = city.IsTop,
            };

            return ApiResult<UpdateCityResponse>.OK(response);
        }
    }
}
