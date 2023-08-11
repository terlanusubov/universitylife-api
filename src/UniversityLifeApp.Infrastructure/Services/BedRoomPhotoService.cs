using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoomPhoto.AddBedRoomPhoto;
using UniveristyLifeApp.Models.v1.Countries.AddCountry;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.AddBedRoomPhoto;
using UniversityLifeApp.Application.CQRS.v1.BedRoomPhoto.Commands.UpdateBedRoomPhoto;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class BedRoomPhotoService : IBedRoomPhotoService
    {
        private readonly ApplicationContext _applicationContext;
        private readonly IWebHostEnvironment _environment;
        private readonly IFileService _fileService;

        public BedRoomPhotoService(ApplicationContext applicationContext, IWebHostEnvironment environment,IFileService fileService)
        {
            _applicationContext = applicationContext;
            _environment = environment;
            _fileService = fileService;
        }
        public async Task<ApiResult<AddBedRoomPhotoResponse>> AddBedroomPhoto(AddBedRoomPhotoCommand request)
        {
            BedRoomPhoto bedRoomPhoto = new BedRoomPhoto()
            {
                BedroomId = request.Request.BedroomId,
                IsMain = request.Request.IsMain,
                IsActive = request.Request.IsActive,
            };
            bedRoomPhoto.Name = await _fileService.SaveImage(_environment.WebRootPath, "uploads/bedroomPhoto", request.Request.ImageFile);
            await _applicationContext.BedRoomPhotos.AddAsync(bedRoomPhoto);
            await _applicationContext.SaveChangesAsync();

            var response = new AddBedRoomPhotoResponse()
            {
                Name = bedRoomPhoto.Name,
                IsActive = bedRoomPhoto.IsActive,
                IsMain = bedRoomPhoto.IsMain,
            };

            return ApiResult<AddBedRoomPhotoResponse>.OK(response);
        }

        //public async Task<ApiResult<AddBedRoomPhotoResponse>> UpdateBedRoomPhoto(UpdateBedRoomPhotoCommand requset, int id)
        //{
        //    var result = await _applicationContext.BedRoomPhotos.FindAsync(id);
        //    result.IsMain = requset.Req
        //}
    }
}
