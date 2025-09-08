using WebApi.Infrastructure.Repositories;
using WebApi.Domain.Repositories;

namespace WebApi.Bindings;

public static class RepositoryBindings
{
    public static IServiceCollection AddRepositories( this IServiceCollection services )
    {
        services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();

        return services;
    }
}