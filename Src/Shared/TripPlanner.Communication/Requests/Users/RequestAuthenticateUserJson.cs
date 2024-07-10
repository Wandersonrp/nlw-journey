namespace TripPlanner.Communication.Requests.Users;

public record RequestAuthenticateUserJson
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}