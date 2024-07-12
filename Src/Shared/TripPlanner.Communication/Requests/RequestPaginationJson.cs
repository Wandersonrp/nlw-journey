namespace TripPlanner.Communication.Requests;

public record RequestPaginationJson
{
    public int Page { get; set; }
    
    public int ItemsPerPage { get; set; }
}
