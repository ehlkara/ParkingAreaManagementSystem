using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkAreaManagementSystem.Domain.Core.Repositories;
using ParkAreaManagementSystem.Domain.Core.Repositories.Parking;
using ParkAreaManagementSystem.Infrastructure.Repositories;
using ParkAreaManagementSystem.Infrastructure.Repositories.Parking;

namespace ParkAreaManagementSystem.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IParkingSpotRepository, ParkingSpotRepository>();

        return services;
    }
}