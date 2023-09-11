using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.CreateOurService;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.OurService.Commands.CreateService;
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

            service.Image = await _fileService.SaveImage(_env.WebRootPath, "uploads/services", request.Request.ImageFile);

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

        public async Task<ApiResult<List<GetOurServiceResponse>>> GetOurService()
        {
            var result = await _context.OurServices.Where(x=>x.OurServiceStatusId == (int)OurServiceStatusEnum.Active).Select(x=> new GetOurServiceResponse
            {
                Description = x.Description,
                Name = x.Name,
                Image = "http://highresultech-001-site1.ftempurl.com/uploads/services/" + x.Image,
                Id = x.Id

            }).ToListAsync();

            return ApiResult<List<GetOurServiceResponse>>.OK(result);

        }
    }
}
