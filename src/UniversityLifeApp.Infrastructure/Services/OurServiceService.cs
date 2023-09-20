using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.DeleteOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurServiceById;
using UniveristyLifeApp.Models.v1.OurService.UpdateOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.UpdateOurService;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class OurServiceService : IOurServiceService
    {
        private readonly ApplicationContext _context;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _env;
        public OurServiceService (ApplicationContext context, IFileService fileService, IWebHostEnvironment env)
        {
             _context = context;
            _fileService = fileService;
            _env = env;
        }

        public async Task<ApiResult<CreateOurServiceResponse>> CreateService(CreateServiceCommand request)
        {
            OurService service = new OurService
            {
                Name = request.Request.Name,
                Description = request.Request.Description,
                OurServiceStatusId = (int)OurServiceStatusEnum.Active,
            };

            if (_env.WebRootPath.Contains("MVC"))
            {
                var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                service.Image = await _fileService.SaveImage(path2, "uploads/services", request.Request.ImageFile);
            }
            else
            {
                service.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/services", request.Request.ImageFile);
            }


            await _context.OurServices.AddAsync(service);
            await _context.SaveChangesAsync();
             
            CreateOurServiceResponse response = new CreateOurServiceResponse
            {
                    Name = service.Name,
                Description = service.Description,
                Image = "http://highresultech-001-site1.ftempurl.com/uploads/services/" + service.Image,
                OurServiceStatusId = service.OurServiceStatusId,

            };

            return ApiResult<CreateOurServiceResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteOurServiceResponse>> DeleteService(int serviceId)
        {
            var service = _context.OurServices.Where(x=>x.Id == serviceId).FirstOrDefault();

           

            service.OurServiceStatusId = (int)OurServiceStatusEnum.Deactive;

            await _context.SaveChangesAsync();

            var response = new DeleteOurServiceResponse
            {
                Id = service.Id,
            };

            return ApiResult<DeleteOurServiceResponse>.OK(response);
        }

        public async Task<ApiResult<GetOurServiceResponse>> GetById(int serviceId)
        {
            var service = await _context.OurServices.Where(x => x.Id == serviceId).Select(x => new GetOurServiceResponse
            {
                Name = x.Name,
                Id = x.Id,
                Description = x.Description,
                Image = x.Image,
                OurServiceStatusId = x.OurServiceStatusId
            }).FirstOrDefaultAsync();

            return ApiResult<GetOurServiceResponse>.OK(service);
        }

        public async Task<ApiResult<List<GetOurServiceResponse>>> GetOurService()
        {
            var result = await _context.OurServices.Where(x=>x.OurServiceStatusId == (int)OurServiceStatusEnum.Active).Select(x=> new GetOurServiceResponse
            {
                Description = x.Description,
                Name = x.Name,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Image = "http://highresultech-001-site1.ftempurl.com/uploads/services/" + x.Image,
                Id = x.Id

            }).ToListAsync();

            return ApiResult<List<GetOurServiceResponse>>.OK(result);

        }

        public async Task<ApiResult<UpdateOurServiceResponse>> UpdateService(UpdateOurServiceCommand request, int serviceId)
        {
            var result = await _context.OurServices.Where(x => x.Id == serviceId).FirstOrDefaultAsync();

            result.Name = request.Request.Name;
            result.Description = request.Request.Description;
            if (request.Request.ImageFile != null)
            {
                if (_env.WebRootPath.Contains("MVC"))
                {
                    var path = _env.WebRootPath.Replace("UniversityLifeApp.MVC", "UniversityLifeApp.API");
                    var path2 = path.Replace("universitylife-api", @"universitylife-api\src");
                    _fileService.DeleteImage(path2, "uploads/services", result.Image);
                    result.Image = await _fileService.SaveImage(path2, "uploads/services", request.Request.ImageFile);
                }
                else
                {
                    _fileService.DeleteImage(_env.WebRootPath, "uploads/services", result.Image);
                    result.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/services", request.Request.ImageFile);

                }

            }
            await _context.SaveChangesAsync();

            var response = new UpdateOurServiceResponse
            {
                Description = result.Description,
                Name = result.Name,
                Image = result.Image,
            };

            return ApiResult<UpdateOurServiceResponse>.OK(response);



        }
    }
}
