using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Account.Login;
using UniveristyLifeApp.Models.v1.Account.Register;
using UniveristyLifeApp.Models.v1.Account.Update;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.Account.Commands.Update;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationContext _context;
        private readonly IJWTService _jwtService;
        public AccountService(ApplicationContext context, IJWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (user == null)
            {
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);
            }

            bool check = user.CheckPassword(request.Password);

            if(!check)
            {
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);
            }

            string token = _jwtService.GenerateJwtToken(user);

            var response = new LoginResponse
            {
                Token = token,
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
            };

            return ApiResult<LoginResponse>.OK(response);

        }

        public async Task<ApiResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var users = await _context.Users.Where(x => x.Email == request.Email).FirstOrDefaultAsync();

            if (users != null)
                return ApiResult<RegisterResponse>.Error(ErrorCodes.USER_IS_ALREADY_EXIST);



            User newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                UserStatusId = (int)UserStatusEnum.Active,
                UserRoleId = (int)UserRoleEnum.User,
            };

            newUser.AddPassword(request.Password);

            await _context.Users.AddAsync(newUser);

            await _context.SaveChangesAsync();

            var response = new RegisterResponse
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                UserId = newUser.Id,
                PhoneNumber = request.PhoneNumber,
            };

            return ApiResult<RegisterResponse>.OK(response);
        }

        public async Task<ApiResult<UpdateResponse>> Update(UpdateCommand request)
        {
            var user = await _context.Users.Where(x => x.Id == request.Request.UserId).FirstOrDefaultAsync();

            if(user != null)
            {
                user.Name = request.Request.Name;
                user.Surname = request.Request.Surname;
                user.PhoneNumber = request.Request.PhoneNumber;
            }

            await _context.SaveChangesAsync();

            UpdateResponse response = new UpdateResponse
            {
                Name = user.Name,
                Surname = user.Surname,
                PhoneNumber = user.PhoneNumber,
            };

            return ApiResult<UpdateResponse>.OK(response);

        }
    }
}
