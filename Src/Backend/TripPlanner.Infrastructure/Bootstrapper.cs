using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.LoggedUser;
using TripPlanner.Infrastructure.Data.Context;
using TripPlanner.Infrastructure.Data.Repositories;
using TripPlanner.Infrastructure.Services.LoggedUser;

namespace TripPlanner.Infrastructure;
public static class Bootstrapper
{
    public static void InitializeInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
        AddLoggedUser(services);
    }

    public static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TripPlannerDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }

    private static void AddLoggedUser(IServiceCollection services)
    {
        services.AddScoped<ILoggedUser, LoggedUser>();
    }
}
