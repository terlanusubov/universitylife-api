using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.UserRole.CreateRole;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.UserRole.Commands.CreateUserRole
{
    public class CreateUserRoleCommand:IRequest<ApiResult<UserRoleResponse>>
    {
        public CreateUserRoleCommand(UserRoleRequest request)
        {
            Request = request;
        }

        public UserRoleRequest Request { get; set; }
    }
}
