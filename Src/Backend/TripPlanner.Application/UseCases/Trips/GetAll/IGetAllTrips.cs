using TripPlanner.Communication.Requests;
using TripPlanner.Communication.Responses.Trips;

namespace TripPlanner.Application.UseCases.Trips.GetAll;

public interface IGetAllTrips
{
    Task<ResponseGetAllTripsJson> Execute(RequestPaginationJson request);
}
