using TripPlanner.Communication.Responses.Trips;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.LoggedUser;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.Application.UseCases.Trips.GetById;

public class GetTripByIdUseCase : IGetTripById
{
    private readonly ITripRepository _tripRepository;
    private readonly ILoggedUser _loggedUser;

    public GetTripByIdUseCase(ITripRepository tripRepository, ILoggedUser loggedUser)
    {
        _tripRepository = tripRepository;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseGetTripJson> Execute(string id)
    {
        await _loggedUser.User();

        var tripIdParsed = Guid.Parse(id);

        var trip = await _tripRepository.FindByIdAsync(tripIdParsed) ??
            throw new ResourceNotFoundException(id);

        return new ResponseGetTripJson
        { 
            Id = trip.Id,
            Origin = trip.Origin,
            Destination = trip.Destination,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            UserId = trip.UserId,
            CreatedAt = trip.CreatedAt,
            UpdatedAt = trip.UpdatedAt            
        };
    }
}
