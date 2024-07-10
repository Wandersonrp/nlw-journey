using TripPlanner.Domain.Entities;

namespace TripPlanner.Application.Services.Auth.Jwt.Generator;
public interface IAccessTokenGenerator
{
    string GenerateToken(User user);
}
