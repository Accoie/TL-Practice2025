using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Services;
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
    public ActionResult<List<SearchResultDto>> Search( [FromQuery] SearchFilter filter )
    {
        try
        {
            List<(Property, RoomType)> searchedData = _searchService.Search( filter ).ToList();

            List<SearchResultDto> result = [];

            foreach ( (Property, RoomType) data in searchedData )
            {
                SearchResultDto resultDto = new();

                resultDto.Property = Mapper.ToPropertyDto( data.Item1 );
                resultDto.RoomType = Mapper.ToRoomTypeDto( data.Item2 );

                result.Add( resultDto );
            }

            return Ok( result );
        }
        catch ( ArgumentException ex )
        {
            return BadRequest( ex.Message );
        }
    }
}