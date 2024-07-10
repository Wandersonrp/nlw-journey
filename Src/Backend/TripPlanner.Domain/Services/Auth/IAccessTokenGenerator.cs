using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Services.Auth;

public interface IAccessTokenGenerator
{
    string GenerateToken(User user);
}
