using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniveristyLifeApp.Models.v1.Search;
using UniversityLifeApp.Application.Core;
using UniversityLifeApp.Application.Interfaces;

namespace UniversityLifeApp.Application.CQRS.v1.Search.Commands.Search
{
    public class SearchCommandHandler : IRequestHandler<SearchCommand, ApiResult<List<SearchResponse>>>
    {
        private readonly ISearchService _searchService;

        public SearchCommandHandler(ISearchService searchService)
        {
            _searchService = searchService;
        }
        public Task<ApiResult<List<SearchResponse>>> Handle(SearchCommand request, CancellationToken cancellationToken)
        {
            var result = _searchService.Search(request.Request.Word);
            return result;
        }
    }
}
