using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Services.Interfaces;
using WebApi.Mapping;

namespace WebApi.Controllers;

[Route( "api/search" )]
[ApiController]
public class SearchController : ControllerBase
{
    private ISearchService _searchService;

    public SearchController( ISearchService searchService )
    {
        _searchService = searchService;
    }

    [HttpGet]
    public async Task<List<SearchResultDto>> Search( [FromQuery] SearchFilter filter )
    {
        List<(Property, RoomType)> searchedData = await _searchService.Search( filter );

        List<SearchResultDto> result = SearchMapper.ToSearchResultDtos( searchedData );

        return result;
    }
}