namespace TripPlanner.Communication.Requests.Trips;

public record RequestCreateTripJson
{
    public string Origin { get; set; } = string.Empty;    
    public string Destination { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid UserId { get; set; }
}