using TripPlanner.Communication.Enums.Activities;

namespace TripPlanner.Domain.Entities;
public class Activity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Status Status { get; set; } = Status.Pending;
    public Guid TripId { get; set; }
    public Trip Trip { get; set; } = null!;
}
