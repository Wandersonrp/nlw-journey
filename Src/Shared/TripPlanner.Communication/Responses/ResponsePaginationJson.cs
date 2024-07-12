using System.Text.Json.Serialization;

namespace TripPlanner.Communication.Responses;

public record ResponsePaginationJson
{    
    public int Page { get; set; }
    
    public int ItemsPerPage { get; set; }
    
    public int TotalItems { get; set; }
    
    public double TotalPages { get; set; }
}
