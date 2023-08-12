using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserRole.CreateRole;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.UserRole.Commands.CreateUserRole
{
    public class CreateUserRoleCommandHandler : IRequestHandler<CreateUserRoleCommand, ApiResult<UserRoleResponse>>
    {
        private readonly IUserRoleService _userRoleService;
        public CreateUserRoleCommandHandler(IUserRoleService userRoleService)
            => _userRoleService = userRoleService;
        public async Task<ApiResult<UserRoleResponse>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _userRoleService.Create(request);

            return result;
        }
    }
}
