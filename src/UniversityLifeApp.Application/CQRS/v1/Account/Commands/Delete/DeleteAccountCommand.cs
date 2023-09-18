using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Delete;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Account.Commands.Delete
{
    public class DeleteAccountCommand : IRequest<ApiResult<DeleteAccountResponse>>
    {
        public DeleteAccountCommand(int accountId)
        {
            AccountId = accountId;
        }

        public int AccountId { get; set; }
    }
}
