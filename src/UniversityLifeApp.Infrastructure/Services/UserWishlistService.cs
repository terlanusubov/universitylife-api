using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.BedRoom.GetBedRoom;
using UniveristyLifeApp.Models.v1.UserWishlist.CreateUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.DeleteUserWishlist;
using UniveristyLifeApp.Models.v1.UserWishlist.GetUserWishlist;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.CQRS.v1.UserWishlist.Queries.GetUserWishlist;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class UserWishlistService : IUserWishlistService
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        public UserWishlistService(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ApiResult<CreateUserWishlistResponse>> CreateUserWishlist(CreateUserWishlistRequest request)
        {
            var userWishlist = await _context.UserWishlists.ToListAsync();

            foreach (var item in userWishlist)
            {
                if(item.UserId == request.UserId && item.BedRoomId == request.BedRoomId)
                {
                    return ApiResult<CreateUserWishlistResponse>.Error(ErrorCodes.WISHLIST_IS_ALREADY_EXIST , null , (int)HttpStatusCode.AlreadyReported);
                }
            }

            UserWishlist wish = new UserWishlist
            {
                UserId = request.UserId,
                BedRoomId = request.BedRoomId,
            };

            await _context.UserWishlists.AddAsync(wish);
            await _context.SaveChangesAsync();

            var response = new CreateUserWishlistResponse
            {
                UserId = wish.UserId,
                BedRoomId = wish.BedRoomId,
                UserWishlistId = wish.Id,
            };

            return ApiResult<CreateUserWishlistResponse>.OK(response);
        }

        public async Task<ApiResult<DeleteUserWishlistResponse>> Delete(int wishId)
        {
            var wish = await _context.UserWishlists.Where(x => x.Id == wishId).FirstOrDefaultAsync();

            if (wish != null)
            {
                _context.UserWishlists.Remove(wish);
                await _context.SaveChangesAsync();
            }

            DeleteUserWishlistResponse response = new DeleteUserWishlistResponse
            {
                UserId = wish.UserId,
                BedRoomId = wish.BedRoomId,
                UserWishlistId = wish.Id,
            };

            return ApiResult<DeleteUserWishlistResponse>.OK(response);
        }

        public async Task<ApiResult<List<GetUserWishlistResponse>>> GetUserWishlist(GetUserWishlistRequest request)
        {
            var baseUrl = _configuration["BaseUrl"];



            var Wishlist = await _context.UserWishlists.Where(x=>x.UserId == request.UserId).Select(x=> new GetUserWishlistResponse
            {
                UserId = x.UserId,
                UserWishlistId = x.Id,
                Id = x.BedRoom.Id,
                BedRoomRoomTypes = x.BedRoom.RoomTypes.Select(x => x.BedRoomRoomType.Name).ToList(),
                BedRoomStatusId = x.BedRoom.BedRoomStatusId,
                BedRoomImages = x.BedRoom.BedRoomPhotos.Select(c => baseUrl + "bedroomPhoto/" + c.Name).ToList(),
                CityId = x.BedRoom.CityId,
                Description = x.BedRoom.Description,
                DistanceToCenter = x.BedRoom.DistanceToCenter,
                Latitude = x.BedRoom.Latitude,
                Longitude = x.BedRoom.Longitude,
                Name = x.BedRoom.Name,
                Price = x.BedRoom.Price,
                Rating = x.BedRoom.Rating,


            }).ToListAsync();

            return ApiResult<List<GetUserWishlistResponse>>.OK(Wishlist);        }
    }
}
