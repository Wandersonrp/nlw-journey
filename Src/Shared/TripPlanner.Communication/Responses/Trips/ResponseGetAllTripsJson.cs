namespace TripPlanner.Communication.Responses.Trips;

public record ResponseGetAllTripsJson
{
    public ResponsePaginationJson Pagination { get; set; } = null!;
    public ICollection<ResponseGetTripJson> Trips { get; set; } = new List<ResponseGetTripJson>();
}
