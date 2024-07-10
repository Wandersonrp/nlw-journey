namespace TripPlanner.Communication.Responses.Trips;

public record ResponseCreateTripJson
{
    public Guid Id { get; set; }
    public string Origin { get; set; } = string.Empty;    
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}