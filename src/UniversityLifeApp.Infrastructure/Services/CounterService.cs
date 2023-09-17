using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Counter.GetCounter;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class CounterService : ICounterService
    {
        private readonly ApplicationContext _applicationContext;

        public CounterService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<ApiResult<GetCounterResponse>> GetCounter()
        {
            int user = _applicationContext.Users.Count();
            int bedroom = _applicationContext.BedRooms.Count();
            int cities = _applicationContext.Cities.Count();
            int university = _applicationContext.Universities.Count();

            GetCounterResponse getCounterResponse = new GetCounterResponse
            {
                UniversityCount = university,
                StudentCount = user,
                BedRoomCount = bedroom,
                CityCount = cities,
            };

            return ApiResult<GetCounterResponse>.OK(getCounterResponse);
            
        }
    }
}
