using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.CloseBedRoom.GetCloseBedRoom;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class GetCloseBedroom : IGetCloseBedroom
    {
        private readonly ApplicationContext _context;

        public GetCloseBedroom(ApplicationContext context)
        {
            _context = context;
        }
        async Task<ApiResult<GetCloseBedRoomResponse>> IGetCloseBedroom.GetCloseBedroom(int universityId)
        {
            var geUniCityId = await _context.Universities.Where(x => x.Id == universityId).Select(x => x.CityId).FirstOrDefaultAsync();
            int cityId = geUniCityId;
            var uniLongitude = await _context.Universities.Where(x => x.Id == universityId).Select(x => x.Longitude).FirstOrDefaultAsync();
            double lon = Convert.ToDouble(uniLongitude);    
            var uniLatitude = await _context.Universities.Where(x => x.Id == universityId).Select(x => x.Latitude).FirstOrDefaultAsync();
            double lat = Convert.ToDouble(uniLatitude);
            var getBedroomByCity = await _context.BedRooms.Where(x => x.CityId == cityId).ToListAsync();

            GetCloseBedRoomResponse response = new GetCloseBedRoomResponse();

            List<IDictionary<int, double>> responseList = new();

            for (int i = 0; i < getBedroomByCity.Count; i++)
            {
                const double radius = 6371;
                double lat2 = Convert.ToDouble(getBedroomByCity[i].Latitude);
                double lon2 = Convert.ToDouble(getBedroomByCity[i].Longitude);

                double radLat1 = ToRadians(lat);
                double radLon1 = ToRadians(lon);
                double radLat2 = ToRadians(lat2);
                double radLon2 = ToRadians(lon2);

                double dLon = radLon2 - radLon1;
                double dLat = radLat2 - radLat1;

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                           Math.Cos(radLat1) * Math.Cos(radLat2) *
                           Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                double distance = radius * c;

                IDictionary<int, double> map = new Dictionary<int, double>();
                map.Add(getBedroomByCity[i].Id, distance);

                responseList.Add(map);
                response.Response = responseList;
            }

            return ApiResult<GetCloseBedRoomResponse>.OK(response);
        }
        private static double ToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }
    }
}
