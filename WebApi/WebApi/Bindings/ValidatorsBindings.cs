using FluentValidation;
using WebApi.Domain.Validators;

namespace WebApi.Bindings;

public static class ValidatorBindings
{
    public static IServiceCollection AddValidators( this IServiceCollection services )
    {
        services.AddValidatorsFromAssemblyContaining<PropertyValidator>();
        services.AddValidatorsFromAssemblyContaining<RoomTypeValidator>();
        services.AddValidatorsFromAssemblyContaining<ReservationValidator>();

        return services;
    }
}