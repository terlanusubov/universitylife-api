using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.GetOurService;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Queries.GetOurService
{
    public class GetOurServiceQuery : IRequest<ApiResult<List<GetOurServiceResponse>>>
    {
        public int OurServiceStatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
