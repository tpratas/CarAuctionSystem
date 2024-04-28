using CarAuctionSystem.Application.Common.Interfaces.Repositories;
using CarAuctionSystem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarAuctionSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddRepositories();
        return services;
    }

    public static IServiceCollection AddRepositories(
       this IServiceCollection services)
    {
        services.AddScoped<IVehicleRepository, VehicleRepository>();
        services.AddScoped<IAuctionRepository, AuctionRepository>();
        return services;
    }
}
