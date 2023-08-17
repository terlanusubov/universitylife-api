using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class OurServiceService : IOurServiceService
    {
        private readonly ApplicationContext _context;

        public OurServiceService (ApplicationContext context)
            => _context = context;

        public async Task<ApiResult<List<GetOurServiceResponse>>> GetOurService()
        {
            var result = await _context.OurServices.Where(x=>x.OurServiceStatusId == (int)OurServiceStatusEnum.Active).Select(x=> new GetOurServiceResponse
            {
                Description = x.Description,
                Name = x.Name,
                Image = x.Image,
                OurServiceId = x.Id

            }).ToListAsync();

            return ApiResult<List<GetOurServiceResponse>>.OK(result);

        }
    }
}
