using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TripPlanner.Application.Services.Auth.Jwt.Generator;
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
        (uint expireInMinutes, string signingKey) tuple = GetJwtSettings(configuration);

        services
            .AddScoped<IPasswordEncrypter>(options => new PasswordEncrypter(GetPasswordSalt(configuration)))
            .AddScoped<IAccessTokenGenerator>(options => new JwtTokenGenerator(tuple.expireInMinutes, tuple.signingKey));
    }

    private static string GetPasswordSalt(IConfiguration configuration)
    {
        return configuration["PasswordSalt"] ?? string.Empty;
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUser, RegisterUserUseCase>();
    }

    private static (uint expireInMinutes, string signigkey) GetJwtSettings(IConfiguration configuration)
    {
        var expireInMinutes = uint.Parse(configuration.GetSection("Jwt:ExpireInMinutes").Value ?? throw new ArgumentNullException("Provide Jwt Expire in Minutes"));

        var signigkey = configuration.GetSection("Jwt:SigningKey").Value ?? throw new ArgumentNullException("Provide Jwt Signing Key");

        return (expireInMinutes, signigkey);
    }
}
