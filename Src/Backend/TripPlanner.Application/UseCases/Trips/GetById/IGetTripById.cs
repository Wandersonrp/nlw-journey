using TripPlanner.Communication.Responses.Trips;

namespace TripPlanner.Application.UseCases.Trips.GetById;

public interface IGetTripById
{
    Task<ResponseGetTripJson> Execute(string id);
}
