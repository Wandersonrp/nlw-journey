namespace TripPlanner.Domain.Services.Auth;

public interface IAccessTokenValidator
{
    Guid ValidateAndGetUserIdentifier(string token);
}