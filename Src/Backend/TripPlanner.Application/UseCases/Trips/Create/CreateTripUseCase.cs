using TripPlanner.Communication.Requests.Trips;
using TripPlanner.Communication.Responses.Trips;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.LoggedUser;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.Application.UseCases.Trips.Create;

public class CreateTripUseCase : ICreateTrip
{
    private readonly ILoggedUser _loggedUser;
    private readonly ITripRepository _tripRepository;

    public CreateTripUseCase(ILoggedUser loggedUser, ITripRepository tripRepository)
    {
        _loggedUser = loggedUser;
        _tripRepository = tripRepository;
    }

    public async Task<ResponseCreateTripJson> Execute(RequestCreateTripJson request)
    {
        Validate(request);

        var user = await _loggedUser.User();

        var trip = new Trip
        {
            Origin = request.Origin,
            Destination = request.Destination,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            UserId = user.Id,
        };

        await _tripRepository.AddAsync(trip);

        return new ResponseCreateTripJson
        {
            Id = trip.Id,
            Origin = trip.Origin,
            Destination = trip.Destination,
            StartDate = trip.StartDate,
            EndDate = trip.EndDate,
            UserId = trip.UserId,
            CreatedAt = trip.CreatedAt,
            UpdatedAt = trip.UpdatedAt,
        };
    }

    private static void Validate(RequestCreateTripJson request)
    {
        var validation = new CreateTripValidator();
        
        var result = validation.Validate(request);

        if(!result.IsValid)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
