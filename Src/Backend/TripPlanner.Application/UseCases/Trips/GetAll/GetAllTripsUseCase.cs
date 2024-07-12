using TripPlanner.Communication.Requests;
using TripPlanner.Communication.Responses;
using TripPlanner.Communication.Responses.Trips;
using TripPlanner.Domain.Repositories;

namespace TripPlanner.Application.UseCases.Trips.GetAll;

public class GetAllTripsUseCase : IGetAllTrips
{
    private readonly ITripRepository _tripRepository;

    public GetAllTripsUseCase(ITripRepository tripRepository)
    {
        _tripRepository = tripRepository;     
    }

    public async Task<ResponseGetAllTripsJson> Execute(RequestPaginationJson request)
    {
        var trips = await _tripRepository.FindAllAsync(request.Page, request.ItemsPerPage);

        return new ResponseGetAllTripsJson
        {
            Trips = trips.Select(trip => new ResponseGetTripJson
            {
                Id = trip.Id,
                Origin = trip.Origin,
                Destination = trip.Destination,
                StartDate = trip.StartDate,
                EndDate = trip.EndDate,
                UserId = trip.UserId,
                CreatedAt = trip.CreatedAt,
                UpdatedAt = trip.UpdatedAt
            }).ToList(),
            Pagination = new ResponsePaginationJson
            {
                TotalItems = trips.Count,
                Page = request.Page,
                ItemsPerPage = request.ItemsPerPage,
                TotalPages = (int)Math.Ceiling((double)trips.Count / request.ItemsPerPage)
            }
        };
    }
}
