using FluentValidation;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Validators;

public class ReservationValidator : AbstractValidator<Reservation>
{
    public ReservationValidator()
    {
        RuleFor( reservation => reservation.GuestName )
            .NotEmpty()
            .WithMessage( "Guest name cannot be empty" )
            .Length( 2, 100 )
            .WithMessage( "Guest name must be between 2 and 100 characters" )
            .Matches( @"^[a-zA-Zа-яА-ЯёЁ\s\-']+$" )
            .WithMessage( "Guest name can only contain letters, spaces, hyphens and apostrophes" );

        RuleFor( reservation => reservation.GuestPhoneNumber )
            .NotEmpty()
            .WithMessage( "Guest phone number cannot be empty" )
            .Matches( @"^\+?[0-9\s\-\(\)]{10,20}$" )
            .WithMessage( "Phone number must be in valid format" )
            .MinimumLength( 10 )
            .WithMessage( "Phone number must be at least 10 digits" );

        RuleFor( reservation => reservation.Currency )
            .NotEmpty()
            .WithMessage( "Currency cannot be empty" )
            .Length( 3 )
            .WithMessage( "Currency code must be 3 characters" );

        RuleFor( reservation => reservation.ArrivalDate )
            .LessThan( reservation => reservation.DepartureDate )
            .WithMessage( "Arrival date must be before departure date" )
            .GreaterThanOrEqualTo( DateTime.Today )
            .WithMessage( "Arrival date cannot be in the past" );

        RuleFor( reservation => reservation.DepartureDate )
            .GreaterThan( reservation => reservation.ArrivalDate )
            .WithMessage( "Departure date must be after arrival date" )
            .LessThan( DateTime.Today.AddYears( 1 ) )
            .WithMessage( "Departure date cannot be more than 1 year in advance" );
    }

    public static void ValidatePersonCount( Reservation reservation, RoomType roomType )
    {
        if ( reservation.PersonCount > roomType.MaxPersonCount )
            throw new ArgumentException( $"Too many people for reservation! Max count is {roomType.MaxPersonCount}" );

        if ( reservation.PersonCount < roomType.MinPersonCount )
            throw new ArgumentException( $"Too few people   for reservation! Min count is {roomType.MinPersonCount}" );
    }

    public static void ValidateAvailability( Reservation reservation, List<Reservation> existingReservations )
    {
        foreach ( Reservation existingRes in existingReservations )
        {
            if ( existingRes.Id == reservation.Id )
                continue;

            bool isDateEqual = reservation.ArrivalDate == existingRes.DepartureDate ||
                              reservation.DepartureDate == existingRes.ArrivalDate;

            bool isDateIntersection = IsDateIntersection(
                (reservation.ArrivalDate, reservation.DepartureDate),
                (existingRes.ArrivalDate, existingRes.DepartureDate) );

            if ( isDateEqual || isDateIntersection )
            {
                throw new ArgumentException(
                    $"RoomType \"{reservation.RoomTypeId}\" is already reserved on " +
                    $"{existingRes.ArrivalDate.Date} {existingRes.ArrivalTime} - " +
                    $"{existingRes.DepartureDate.Date} {existingRes.DepartureTime}" );
            }
        }
    }

    public static bool IsDateIntersection( (DateTime Start, DateTime End) firstInterval,
                                         (DateTime Start, DateTime End) secondInterval )
    {
        return firstInterval.End > secondInterval.Start &&
               firstInterval.Start < secondInterval.End;
    }
}