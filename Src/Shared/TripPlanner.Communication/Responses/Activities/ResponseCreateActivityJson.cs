using TripPlanner.Communication.Enums.Activities;

namespace TripPlanner.Communication.Responses.Activities;

public record ResponseCreateActivityJson
{
    public Guid Id { get; set; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public Status Status { get; set; }
    public Guid TripId { get; init; }
}
