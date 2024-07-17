using TripPlanner.Communication.Enums.Activities;

namespace TripPlanner.Communication.Requests.Activities;

public record RequestCreateActivityJson
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public Status Status { get; set; } = Status.Pending;
    public Guid TripId { get; init; }
}
