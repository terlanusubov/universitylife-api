using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Search;
using UniversityLifeApp.Application.Core;

namespace UniversityLifeApp.Application.CQRS.v1.Search.Commands.Search
{
    public class SearchCommand:IRequest<ApiResult<List<SearchResponse>>>
    {
        public SearchCommand(SearchRequest request)
        {
            Request = request;
        }
        public SearchRequest Request { get; set; }
    }
}
