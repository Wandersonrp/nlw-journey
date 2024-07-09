namespace TripPlanner.Domain.Entities;

public class Trip : BaseEntity
{
    public string Origin { get; set; } = string.Empty;
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<Activity> Activities { get; } = new List<Activity>();
}
