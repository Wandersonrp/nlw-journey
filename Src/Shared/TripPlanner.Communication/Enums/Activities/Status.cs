using System.Text.Json.Serialization;

namespace TripPlanner.Communication.Enums.Activities;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Status
{
    Pending,
    Completed,
    Canceled,
    InProgress,
    Rescheduled
}
