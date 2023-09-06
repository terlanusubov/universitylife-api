﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Search;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;
using UniversityLifeApp.Domain.Entities;
using UniversityLifeApp.Domain.Enums;
using UniversityLifeApp.Infrastructure.Data;

namespace UniversityLifeApp.Infrastructure.Services
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationContext _applicationContext;
        public SearchService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public async Task<ApiResult<List<SearchResponse>>> Search(string word)
        {
         
                var cities = await _applicationContext.Cities.Include(x => x.Country).Where(x=>x.Name.ToLower().Contains(word.ToLower())).
                   Select(x => new SearchResponse
                   {
                       Name = x.Name,
                       Country = x.Country.Name,
                       SearchId = (int)SearchStatusEnum.City
                   }).ToListAsync();

                var univercity = await _applicationContext.Universities.Include(x => x.City).
                                                                    ThenInclude(x => x.Country).
                                                                      Where(x => x.Name.ToLower().Contains(word.ToLower())).
                                                                      Select(x => new SearchResponse
                                                                      {
                                                                          Name = x.Name,
                                                                          City = x.City.Name,
                                                                          Country = x.City.Country.Name
                                                                      }).ToListAsync();


            List<SearchResponse> response = new List<SearchResponse>();

            foreach (var item in cities)
            {
                response.Add(item);   
            }

            foreach (var item in univercity)
            {
                response.Add(item);
            }

            return ApiResult<List<SearchResponse>>.OK(response);
        }
    }
}
