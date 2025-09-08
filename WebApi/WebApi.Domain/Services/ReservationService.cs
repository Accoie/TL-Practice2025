using FluentValidation;
using WebApi.Domain.Entities;
using WebApi.Domain.Filters;
using WebApi.Domain.Foundations;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services.Interfaces;
using WebApi.Domain.Validators;

namespace WebApi.Domain.Services;

public class ReservationService : IReservationService
{
    private readonly IRoomTypeService _roomTypeService;
    private readonly IPropertyService _propertyService;
    private readonly IReservationRepository _reservationRepository;
    private readonly IValidator<Reservation> _validator;
    private readonly IUnitOfWork _unitOfWork;

    public ReservationService(
        IPropertyService propertyService,
        IRoomTypeService roomTypeService,
        IReservationRepository reservationRepository,
        IUnitOfWork unitOfWork,
        IValidator<Reservation> validator )
    {
        _roomTypeService = roomTypeService;
        _propertyService = propertyService;
        _reservationRepository = reservationRepository;
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    public async Task CreateOrUpdate( Reservation reservation )
    {
        RoomType roomType = await _roomTypeService.GetById( reservation.RoomTypeId );

        reservation.CalculateTotalPrice( roomType );

        Reservation? existingReservation = await _reservationRepository.GetByIdAsync( reservation.Id );

        if ( existingReservation is null )
        {
            await ProcessReservationValidation( reservation );
            await _reservationRepository.CreateAsync( reservation );
        }
        else
        {
            existingReservation.Update( reservation );
            await ProcessReservationValidation( existingReservation );
            _reservationRepository.Update( existingReservation );
        }

        await _unitOfWork.CommitAsync();
    }

    public async Task Delete( int id )
    {
        Reservation reservation = await GetById( id );

        _reservationRepository.Delete( reservation );

        await _unitOfWork.CommitAsync();
    }

    public async Task<List<Reservation>> GetAll( ReservationFilter? filter = null )
    {
        IEnumerable<Reservation> reservations = await _reservationRepository.GetAllAsync();

        if ( filter is null )
            return reservations.ToList();

        return reservations
            .Where( r => !filter.PropertyId.HasValue || r.PropertyId == filter.PropertyId.Value )
            .Where( r => !filter.RoomTypeId.HasValue || r.RoomTypeId == filter.RoomTypeId.Value )
            .Where( r => !filter.ArrivalDate.HasValue || r.ArrivalDate >= filter.ArrivalDate.Value )
            .Where( r => !filter.DepartureDate.HasValue || r.DepartureDate <= filter.DepartureDate.Value )
            .Where( r => !filter.ArrivalTime.HasValue || r.ArrivalTime >= filter.ArrivalTime.Value )
            .Where( r => !filter.DepartureTime.HasValue || r.DepartureTime <= filter.DepartureTime.Value )
            .Where( r => !filter.PersonCount.HasValue || r.PersonCount == filter.PersonCount.Value )
            .Where( r => string.IsNullOrEmpty( filter.GuestName ) || r.GuestName == filter.GuestName )
            .Where( r => string.IsNullOrEmpty( filter.GuestPhoneNumber ) || r.GuestPhoneNumber == filter.GuestPhoneNumber )
            .Where( r => string.IsNullOrEmpty( filter.Currency ) || r.Currency == filter.Currency )
            .ToList();
    }

    public async Task<List<Reservation>> GetAllById( int? propertyId, int? roomTypeId )
    {
        ReservationFilter filter = new()
        {
            PropertyId = propertyId,
            RoomTypeId = roomTypeId
        };

        return await GetAll( filter );
    }

    public async Task<Reservation> GetById( int id )
    {
        Reservation? reservation = await _reservationRepository.GetByIdAsync( id );

        if ( reservation is null )
        {
            throw new ArgumentException( "Reservation is not found" );
        }

        return reservation;
    }

    private async Task ProcessReservationValidation( Reservation reservation )
    {
        await _validator.ValidateAndThrowAsync( reservation );

        RoomType roomType = await _roomTypeService.GetById( reservation.RoomTypeId );
        Property property = await _propertyService.GetById( reservation.PropertyId );

        List<Reservation> reservations = await GetAllById( reservation.PropertyId, reservation.RoomTypeId );

        ReservationValidator.ValidatePersonCount( reservation, roomType );
        ReservationValidator.ValidateAvailability( reservation, reservations );
    }
}