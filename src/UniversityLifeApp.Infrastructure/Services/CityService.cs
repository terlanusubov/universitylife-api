using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Cities.AddCity;
using UniveristyLifeApp.Models.v1.Cities.DeleteCity;
using UniveristyLifeApp.Models.v1.Cities.GetCity;
using UniveristyLifeApp.Models.v1.Cities.GetCityById;
using UniveristyLifeApp.Models.v1.Cities.UpdateCity;
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
        public CityService(ApplicationContext context, IWebHostEnvironment env, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
            _env = env;
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
                IsTop = request.Request.IsTop
            };

            if (_env.WebRootPath.Contains("MVC"))
            {
                var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                city.Image = await _fileService.SaveImage(path2, "uploads/city", request.Request.ImageFile);
            }
            else
            {
                city.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/city", request.Request.ImageFile);
            }



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
            var cities = await _context.Cities.Include(x => x.Country).Where(x => x.CityStatusId == (int)CityStatusEnum.Active && (request.IsTop != null ? x.IsTop == request.IsTop : true) && (request.CountryId != null ? x.CountryId == request.CountryId : true)).Select(x => new GetCityResponse

            {
                Id = x.Id,
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CountryId = x.CountryId,
                BedRoomCount = x.BedRooms.Count(),
                IsTop = x.IsTop,
                Image = "http://highresultech-001-site1.ftempurl.com/uploads/city/" + x.Image,
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

            if (request.Request.ImageFile != null)
            {
                if (_env.WebRootPath.Contains("MVC"))
                {
                    var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                    var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                    _fileService.DeleteImage(path2, "uploads/city", city.Image);
                    city.Image = await _fileService.SaveImage(path2, "uploads/city", request.Request.ImageFile);
                }
                else
                {
                    _fileService.DeleteImage(_env.WebRootPath, "uploads/city", city.Image);
                    city.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/city", request.Request.ImageFile);

                }

            }

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
