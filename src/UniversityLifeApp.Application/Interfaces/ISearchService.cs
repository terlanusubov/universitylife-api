﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Search;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.Interfaces
{
    public interface ISearchService
    {
        public Task<ApiResult<List<SearchResponse>>> Search(string word);
    }
}
