using WebApi.Domain.Entities;
using WebApi.Domain.Filters;

namespace WebApi.Domain.Services;

public interface ISearchService
{
    public List<(Property, RoomType)> Search( SearchFilter filter );
}