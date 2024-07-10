using TripPlanner.Communication.Requests.Trips;
using TripPlanner.Communication.Responses.Trips;

namespace TripPlanner.Application.UseCases.Trips.Create;

public interface ICreateTrip
{
    Task<ResponseCreateTripJson> Execute(RequestCreateTripJson request);
}