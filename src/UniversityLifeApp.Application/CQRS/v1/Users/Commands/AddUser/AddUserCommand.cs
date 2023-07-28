using System;
using MediatR;
using UniveristyLifeApp.Models.v1.Users.AddUser;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Users.Commands.AddUser
{
    public class AddUserCommand : IRequest<ApiResult<AddUserResponse>>
    {

        public AddUserRequest Model { get; set; }
        public AddUserCommand(AddUserRequest request)
        {
            Model = request;
        }

        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ApiResult<AddUserResponse>>
        {
            

            public async Task<ApiResult<AddUserResponse>> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                return ApiResult<AddUserResponse>.Ok(new AddUserResponse
                {
                    UserId = 1
                });
            }
        }
    }
}

