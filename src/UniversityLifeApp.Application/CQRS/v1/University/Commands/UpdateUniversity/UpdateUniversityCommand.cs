using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.UpdateUniversity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.UpdateUniversity
{
    public class UpdateUniversityCommand:IRequest<ApiResult<UpdateUniversityResponse>>
    {
        public UpdateUniversityCommand(UpdateUniversityRequest request, int universityId)
        {
            Request = request;
            UniversityId = universityId;
        }
        public int UniversityId { get; set; }
        public UpdateUniversityRequest Request { get; set; }
    }
}
