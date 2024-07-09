using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripPlanner.Application.Services.PasswordEncrypter;
using TripPlanner.Application.UseCases.Users.Register;
using TripPlanner.Infrastructure;

namespace TripPlanner.Application;
public static class Bootstrapper
{
    public static void InitializeApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.InitializeInfra(configuration);
        AddServices(services, configuration);
        AddUseCases(services);
    }

    private static void AddServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IPasswordEncrypter>(options => new PasswordEncrypter(GetPasswordSalt(configuration)));
    }

    private static string GetPasswordSalt(IConfiguration configuration)
    {
        return configuration["PasswordSalt"] ?? string.Empty;
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUser, RegisterUserUseCase>();
    }
}
