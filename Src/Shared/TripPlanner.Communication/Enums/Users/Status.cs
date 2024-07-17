using System.Text.Json.Serialization;

namespace TripPlanner.Communication.Enums.Users;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Active, 
    Inactive
}
