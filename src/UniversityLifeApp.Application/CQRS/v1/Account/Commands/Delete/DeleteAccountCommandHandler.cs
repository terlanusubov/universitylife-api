using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Delete;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Delete
{
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand, ApiResult<DeleteAccountResponse>>
    {
        private readonly IAccountService _service;
        public DeleteAccountCommandHandler(IAccountService service)
        {
            _service = service;
        }
        public async Task<ApiResult<DeleteAccountResponse>> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Delete(request.AccountId);
            return result;
        }
    }
}
