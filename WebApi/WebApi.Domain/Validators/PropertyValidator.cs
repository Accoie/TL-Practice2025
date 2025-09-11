using FluentValidation;
using WebApi.Domain.Entities;

namespace WebApi.Domain.Validators;

public class PropertyValidator : AbstractValidator<Property>
{
    public PropertyValidator()
    {
        RuleFor( property => property.Name )
            .NotEmpty().WithMessage( "Property name cannot be empty" )
            .MaximumLength( 100 ).WithMessage( "Property name cannot exceed 100 characters" );

        RuleFor( property => property.Country )
            .NotEmpty().WithMessage( "Country cannot be empty" )
            .MaximumLength( 50 ).WithMessage( "Country name cannot exceed 50 characters" );

        RuleFor( property => property.City )
            .NotEmpty().WithMessage( "City cannot be empty" )
            .MaximumLength( 50 ).WithMessage( "City name cannot exceed 50 characters" );

        RuleFor( property => property.Address )
            .NotEmpty().WithMessage( "Address cannot be empty" )
            .MaximumLength( 200 ).WithMessage( "Address cannot exceed 200 characters" );

        RuleFor( property => property.Latitude )
            .InclusiveBetween( -90m, 90m ).WithMessage( "Latitude must be between -90 and 90 degrees" );

        RuleFor( property => property.Longitude )
            .InclusiveBetween( -180m, 180m ).WithMessage( "Longitude must be between -180 and 180 degrees" );
    }
}
