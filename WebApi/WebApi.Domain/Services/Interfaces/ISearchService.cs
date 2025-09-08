using WebApi.Domain.Entities;
using WebApi.Domain.Filters;

namespace WebApi.Domain.Services.Interfaces;

public interface ISearchService
{
    public Task<List<(Property, RoomType)>> Search( SearchFilter filter );
}