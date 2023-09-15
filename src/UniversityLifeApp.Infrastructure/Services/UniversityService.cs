using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.CreateUniversity;
using UniveristyLifeApp.Models.v1.University.DeleteUniversity;
using UniveristyLifeApp.Models.v1.University.GetUniversity;
using UniveristyLifeApp.Models.v1.University.GetUniversityById;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.CreateUniversity;
using UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly ApplicationContext _context;
        public UniversityService(ApplicationContext context)
            => _context = context;

        public async Task<ApiResult<CreateUniversityResponse>> Create(CreateUniversityCommand request)
        {
            University university = new University
            {
                Name = request.Request.Name,
                CityId = request.Request.CityId,
                Latitude = request.Request.Latitude,
                Longitude = request.Request.Longitude,
                UniversityStatusId = (int)UniversityStatusEnum.Active,
            };

            await _context.Universities.AddAsync(university);
            await _context.SaveChangesAsync();

            var response = new CreateUniversityResponse
            {
                UniversityId = university.Id,
                Name = university.Name,
                CityId = university.CityId,
                Latitude = university.Latitude,
                Longitude = university.Longitude,
            };

            return ApiResult<CreateUniversityResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteUniversityResponse>> Delete(int universityId)
        {
            var university = await _context.Universities.Where(x => x.Id == universityId).FirstOrDefaultAsync();

            university.UniversityStatusId = (int)UniversityStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            DeleteUniversityResponse response = new DeleteUniversityResponse
            {
                Name = university.Name,
                CityId=university.CityId,
                Latitude=university.Latitude,
                Longitude=university.Longitude,
                UniversityId = university.Id,
                UniversityStatusId = university.UniversityStatusId
            };

            return ApiResult<DeleteUniversityResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetUniversityResponse>>> Get()
        {
            var universities = await _context.Universities.Where(x => x.UniversityStatusId == (int)UniversityStatusEnum.Active).Select(x => new GetUniversityResponse
            {
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CityId = x.CityId,
                City = x.City,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                UniversityId = x.Id,
                UniversityStatusId = x.UniversityStatusId,
            }).ToListAsync();

            return ApiResult<List<GetUniversityResponse>>.OK(universities);
        }

        public async Task<ApiResult<GetUniversityByIdResponse>> GetById(int universityId)
        {
            var university = await _context.Universities.Where(x => x.Id == universityId).Select(x => new GetUniversityByIdResponse
            {
                Name = x.Name,
                Latitude = x.Latitude,
                Longitude = x.Longitude,
                CityId = x.CityId,
                UniversityId = x.Id,
                UniversityStatusId = x.UniversityStatusId,
            }).FirstOrDefaultAsync();

            return ApiResult<GetUniversityByIdResponse>.OK(university);
        }

        public async Task<ApiResult<UpdateUniversityResponse>> Update(UpdateUniversityCommand request, int universityId)
        {
            var university = await _context.Universities.Where(x => x.Id == universityId).FirstOrDefaultAsync();

            university.Name = request.Request.Name;
            university.Latitude = request.Request.Latitude;
            university.Longitude = request.Request.Longitude;
            university.CityId = request.Request.CityId;

            await _context.SaveChangesAsync();

            var response = new UpdateUniversityResponse
            {
                UniversityId = university.Id,
                Name = university.Name,
                CityId = university.CityId,
                Latitude = university.Latitude,
                Longitude = university.Longitude,
                UniversityStatusId = university.UniversityStatusId,
            };

            return ApiResult<UpdateUniversityResponse>.OK(response);
        }
    }
}
