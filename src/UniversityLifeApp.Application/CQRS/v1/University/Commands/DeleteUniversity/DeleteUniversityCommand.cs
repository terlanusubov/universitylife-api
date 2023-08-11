using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.University.DeleteUniversity;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.University.Commands.DeleteUniversity
{
    public class DeleteUniversityCommand:IRequest<ApiResult<DeleteUniversityResponse>>
    {
        public DeleteUniversityCommand(int universityId)
        {
            UniversityId = universityId;
        }

        public int UniversityId { get; set; }
    }
}
