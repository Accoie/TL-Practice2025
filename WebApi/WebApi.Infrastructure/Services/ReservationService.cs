using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Infrastructure.Services;

public class ReservationService : IReservationService
{
    private readonly IPropertyRepository _propertyRepository;
    private readonly IRoomTypeRepository _roomTypeRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public ReservationService(
        IPropertyRepository propertyRepository,
        IRoomTypeRepository roomTypeRepository,
        IReservationRepository reservationRepository,
        IUnitOfWork unitOfWork )
    {
        _propertyRepository = propertyRepository;
        _roomTypeRepository = roomTypeRepository;
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
    }

    public void Create( Reservation reservation )
    {
        if ( _reservationRepository.GetById( reservation.Id ) is not null )
        {
            throw new ArgumentException( "Reservation already exists" );
        }

        ValidateReservation( reservation );

        reservation.Total = CalculateTotalPrice( reservation );

        _reservationRepository.Create( reservation );

        _unitOfWork.CommitAsync();
    }

    public void Update( Reservation reservation )
    {
        ValidateReservation( reservation );

        reservation.Total = CalculateTotalPrice( reservation );

        _reservationRepository.Update( reservation );

        _unitOfWork.CommitAsync();
    }

    public void Delete( int id )
    {
        Reservation reservation = GetById( id );

        _reservationRepository.Delete( reservation );

        _unitOfWork.CommitAsync();
    }

    public List<Reservation> GetAll( ReservationFilter? filter = null )
    {
        IEnumerable<Reservation> reservations = _reservationRepository.GetAll();

        if ( filter is null )
        {
            return reservations.ToList();
        }

        if ( filter.PropertyId.HasValue )
        {
            reservations = reservations.Where( r => r.PropertyId == filter.PropertyId.Value );
        }

        if ( filter.RoomTypeId.HasValue )
        {
            reservations = reservations.Where( r => r.RoomTypeId == filter.RoomTypeId.Value );
        }

        if ( filter.ArrivalDate.HasValue )
        {
            reservations = reservations.Where( r => r.ArrivalDate >= filter.ArrivalDate.Value );
        }

        if ( filter.DepartureDate.HasValue )
        {
            reservations = reservations.Where( r => r.DepartureDate <= filter.DepartureDate.Value );
        }

        if ( filter.ArrivalTime.HasValue )
        {
            reservations = reservations.Where( r => r.ArrivalTime >= filter.ArrivalTime.Value );
        }

        if ( filter.DepartureTime.HasValue )
        {
            reservations = reservations.Where( r => r.DepartureTime <= filter.DepartureTime.Value );
        }

        if ( filter.PersonCount.HasValue )
        {
            reservations = reservations.Where( r => r.PersonCount == filter.PersonCount.Value );
        }

        if ( !string.IsNullOrEmpty( filter.GuestName ) )
        {
            reservations = reservations.Where( r => r.GuestName == filter.GuestName );
        }

        if ( !string.IsNullOrEmpty( filter.GuestPhoneNumber ) )
        {
            reservations = reservations.Where( r => r.GuestPhoneNumber == r.GuestPhoneNumber );
        }

        if ( !string.IsNullOrEmpty( filter.Currency ) )
        {
            reservations = reservations.Where( r => r.Currency == filter.Currency );
        }

        return reservations.ToList();
    }

    public Reservation GetById( int id )
    {
        Reservation? reservation = _reservationRepository.GetById( id );

        if ( reservation is null )
        {
            throw new ArgumentException( "Reservation is not found" );
        }

        return reservation;
    }

    public static bool IsDateIntersection( ValueTuple<DateTime, DateTime> firstDateInterval, ValueTuple<DateTime, DateTime> secondDateInterval )
    {
        return firstDateInterval.Item2 > secondDateInterval.Item1 && firstDateInterval.Item1 < secondDateInterval.Item2;
    }

    private void ValidateReservation( Reservation reservation )
    {
        ValidateGuestInfo( reservation );
        ValidateDates( reservation );
        ValidatePropertyAndRoom( reservation );
        ValidatePersonCount( reservation );
        ValidateAvailability( reservation );
    }

    private void ValidateGuestInfo( Reservation reservation )
    {
        if ( string.IsNullOrEmpty( reservation.GuestName ) )
        {
            throw new ArgumentException( "Guest name cannot be empty" );
        }

        if ( string.IsNullOrEmpty( reservation.GuestPhoneNumber ) )
        {
            throw new ArgumentException( "Guest phone number cannot be empty" );
        }

        if ( string.IsNullOrEmpty( reservation.Currency ) )
        {
            throw new ArgumentException( "Currency cannot be empty" );
        }
    }

    private void ValidateDates( Reservation reservation )
    {
        if ( reservation.ArrivalDate >= reservation.DepartureDate )
        {
            throw new ArgumentException( "Arrival date must be before departure date" );
        }
    }

    private void ValidatePropertyAndRoom( Reservation reservation )
    {
        Property? property = _propertyRepository.GetById( reservation.PropertyId );
        RoomType? roomType = _roomTypeRepository.GetById( reservation.RoomTypeId );

        if ( property is null )
        {
            throw new ArgumentException( $"Property \"{reservation.PropertyId}\" doesn't exist" );
        }

        if ( roomType is null )
        {
            throw new ArgumentException( $"Room \"{reservation.RoomTypeId}\" doesn't exist" );
        }
    }

    private void ValidatePersonCount( Reservation reservation )
    {
        RoomType? roomType = _roomTypeRepository.GetById( reservation.RoomTypeId );

        if ( reservation.PersonCount > roomType.MaxPersonCount )
        {
            throw new ArgumentException( $"Too many people for reservation! Max count is {roomType.MaxPersonCount}" );
        }

        if ( reservation.PersonCount < roomType.MinPersonCount )
        {
            throw new ArgumentException( $"Too few people for reservation! Min count is {roomType.MinPersonCount}" );
        }
    }

    private void ValidateAvailability( Reservation reservation )
    {
        ReservationFilter filter = new();

        filter.PropertyId = reservation.PropertyId;
        filter.RoomTypeId = reservation.RoomTypeId;

        List<Reservation> reservations = GetAll( filter );

        foreach ( Reservation res in reservations )
        {
            bool isDateEqual = reservation.ArrivalDate == res.DepartureDate || reservation.DepartureDate == res.ArrivalDate;
            bool isDateIntersection = IsDateIntersection( (reservation.ArrivalDate, reservation.DepartureDate), (res.ArrivalDate, res.DepartureDate) );

            if ( isDateEqual )
            {
                bool isAvailableTime = reservation.ArrivalTime > res.DepartureTime || reservation.DepartureTime > res.ArrivalTime;

                throw new ArgumentException(
                    $"RoomType \"{reservation.RoomTypeId}\" is already reserved on {res.ArrivalDate.Date} {res.ArrivalTime} - {res.DepartureDate.Date} {res.DepartureTime}" );
            }
            if ( isDateIntersection )
            {
                throw new ArgumentException(
                    $"RoomType \"{reservation.RoomTypeId}\" is already reserved on {res.ArrivalDate.Date} {res.ArrivalTime} - {res.DepartureDate.Date} {res.DepartureTime}" );

            }
        }
    }

    private decimal CalculateTotalPrice( Reservation reservation )
    {
        RoomType? roomType = _roomTypeRepository.GetById( reservation.RoomTypeId );

        if ( roomType is null )
        {
            throw new ArgumentException( $"RoomType \"{reservation.RoomTypeId}\" doesn't exist" );
        }

        int numberOfDays = ( reservation.DepartureDate - reservation.ArrivalDate ).Days;
        decimal totalPrice = roomType.DailyPrice * numberOfDays;

        return totalPrice;
    }
}