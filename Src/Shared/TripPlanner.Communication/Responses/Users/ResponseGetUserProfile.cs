namespace TripPlanner.Communication.Responses.Users;

public record ResponseGetUserProfile
{
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
}