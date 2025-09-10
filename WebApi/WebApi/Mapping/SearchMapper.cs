using WebApi.Data;
using WebApi.Domain.Entities;
using WebApi.Extensions;

namespace WebApi.Mapping;

public static class SearchMapper
{
    public static List<SearchResultDto> ToSearchResultDtos( List<(Property, RoomType)> searchedData )
    {
        List<SearchResultDto> result = new();

        foreach ( (Property, RoomType) data in searchedData )
        {
            SearchResultDto resultDto = new();

            resultDto.Property = data.Item1.ToPropertyDto();
            resultDto.RoomType = data.Item2.ToRoomTypeDto();

            result.Add( resultDto );
        }

        return result;
    }
}