
namespace TripPlanner.Communication.Responses.Users;

public record ResponseAuthenticateUserJson
{
    public string AccessToken { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}