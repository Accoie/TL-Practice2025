using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Services;

public class SearchService : ISearchService
{
    private IPropertyService _propertyService;
    private IRoomTypeService _roomTypeService;
    private IReservationService _reservationService;

    public SearchService( IPropertyService propertyService,
        IRoomTypeService roomTypeService,
        IReservationService reservationService )
    {
        _propertyService = propertyService;
        _roomTypeService = roomTypeService;
        _reservationService = reservationService;
    }

    public List<(Property, RoomType)> Search( SearchFilter filter )
    {
        if ( string.IsNullOrWhiteSpace( filter.City ) )
        {
            throw new ArgumentException( "City must be specified" );
        }

        if ( filter.DepartureDate <= filter.ArrivalDate )
        {
            throw new ArgumentException( "Departure date must be after arrival date" );
        }

        if ( filter.MaxPrice < 0 )
        {
            throw new ArgumentException( "Max price cannot be negative" );
        }

        if ( filter.PersonCount <= 0 )
        {
            throw new ArgumentException( "Person count must be at least 1" );
        }


        return ExecuteSearch( filter );
    }

    private List<(Property, RoomType)> ExecuteSearch( SearchFilter filter )
    {
        List<RoomType> roomTypes = _roomTypeService.GetAll()
            .Where( r => r.DailyPrice <= filter.MaxPrice )
            .Where( r => r.MaxPersonCount >= filter.PersonCount )
            .Where( r => r.MinPersonCount <= filter.PersonCount )
            .ToList();

        List<Property> properties = _propertyService.GetAll()
            .Where( p => p.City.Equals( filter.City, StringComparison.OrdinalIgnoreCase ) )
            .Where( p => roomTypes.Any( r => r.PropertyId == p.Id ) )
            .ToList();

        roomTypes = roomTypes
            .Where( r => properties.Any( p => p.Id == r.PropertyId ) )
            .ToList();

        List<Reservation> reservations = _reservationService.GetAll()
            .Where( res => roomTypes.Any( r => r.Id == res.RoomTypeId ) )
            .Where( res => ReservationService.IsDateIntersection(
                (filter.ArrivalDate, filter.DepartureDate),
                (res.ArrivalDate, res.DepartureDate) ) )
            .ToList();

        roomTypes = roomTypes
            .Where( r => !reservations.Any( res => res.RoomTypeId == r.Id ) )
            .ToList();

        List<(Property, RoomType)> resultList = new();

        foreach ( var roomType in roomTypes )
        {
            var property = properties.FirstOrDefault( p => p.Id == roomType.PropertyId );

            if ( property != null )
            {
                resultList.Add( (property, roomType) );
            }
        }

        return resultList;
    }
}