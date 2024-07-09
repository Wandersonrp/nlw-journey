using TripPlanner.Communication.Enums.Users;

namespace TripPlanner.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Status Status { get; set; } = Status.Active;
    public ICollection<Trip> Trips { get; } = new List<Trip>();
}
