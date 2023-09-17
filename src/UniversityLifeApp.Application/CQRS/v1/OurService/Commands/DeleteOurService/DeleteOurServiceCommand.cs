using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.OurService.DeleteOurService;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.OurService.Commands.DeleteOurService
{
    public class DeleteOurServiceCommand : IRequest<ApiResult<DeleteOurServiceResponse>>
    {
        public DeleteOurServiceCommand(int ServiceId)
        {
            Id = ServiceId;
        }
        public int Id { get; set; }
    }
}
