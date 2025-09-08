using WebApi.Domain.Services;
using WebApi.Domain.Services.Interfaces;

namespace WebApi.Bindings;

public static class AppServicesBindings
{
    public static IServiceCollection AddAppServices( this IServiceCollection services )
    {
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IPropertyService, PropertyService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<ISearchService, SearchService>();

        return services;
    }
}