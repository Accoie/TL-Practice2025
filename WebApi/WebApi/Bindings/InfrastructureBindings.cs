using WebApi.Domain.Foundations;
using WebApi.Infrastructure.Foundations;

namespace WebApi.Bindings;
public static class InfrastructureBindings
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services )
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IActualizer, ReservationActualizer>();
        services.AddRepositories();

        return services;
    }
}