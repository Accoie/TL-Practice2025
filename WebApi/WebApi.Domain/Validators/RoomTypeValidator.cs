using FluentValidation;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Validators;

public class RoomTypeValidator : AbstractValidator<RoomType>
{
    public RoomTypeValidator()
    {
        RuleFor( roomType => roomType.PropertyId )
            .GreaterThan( 0 ).WithMessage( "PropertyId must be greater than 0" );

        RuleFor( roomType => roomType.Name )
            .NotEmpty().WithMessage( "Name cannot be empty or whitespace" )
            .MaximumLength( 100 ).WithMessage( "Name cannot be longer than 100 characters" );

        RuleFor( roomType => roomType.DailyPrice )
            .GreaterThan( 0 ).WithMessage( "DailyPrice must be greater than 0" )
            .LessThanOrEqualTo( 100000000 ).WithMessage( "DailyPrice is too high" );

        RuleFor( roomType => roomType.Currency )
            .NotEmpty().WithMessage( "Currency cannot be empty" )
            .Length( 5 ).WithMessage( "Currency must be a 5-letter code" );

        RuleFor( roomType => roomType.MinPersonCount )
            .GreaterThan( 0 ).WithMessage( "Minimal person count could not be less than 1" );

        RuleFor( roomType => roomType.MaxPersonCount )
            .GreaterThan( 0 ).WithMessage( "Maximal person count could not be less than 1" );

        RuleFor( roomType => roomType )
            .Must( roomType => roomType.MaxPersonCount >= roomType.MinPersonCount )
            .WithMessage( "Maximal person count cannot be less than minimal" );

        RuleFor( roomType => roomType.Services )
            .NotNull().WithMessage( "Services list cannot be null" )
            .Must( services => services != null && services.All( service => !string.IsNullOrWhiteSpace( service ) ) )
            .WithMessage( "Services cannot contain empty or whitespace values" );

        RuleFor( roomType => roomType.Amenities )
            .NotNull().WithMessage( "Amenities list cannot be null" )
            .Must( amenities => amenities != null && amenities.All( amenity => !string.IsNullOrWhiteSpace( amenity ) ) )
            .WithMessage( "Amenities cannot contain empty or whitespace values" );
    }
}