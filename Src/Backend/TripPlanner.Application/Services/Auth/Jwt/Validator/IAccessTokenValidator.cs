namespace TripPlanner.Application.Services.Auth.Jwt.Validator;

public interface IAccessTokenValidator
{
    Guid ValidateAndGetUserIdentifier(string token);
}