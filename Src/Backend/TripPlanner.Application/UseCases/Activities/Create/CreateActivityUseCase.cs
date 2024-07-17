using TripPlanner.Communication.Requests.Activities;
using TripPlanner.Communication.Responses.Activities;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.LoggedUser;
using TripPlanner.Exceptions;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.Application.UseCases.Activities.Create;

public class CreateActivityUseCase : ICreateActivity
{
    private readonly IActivityRepository _activityRepository;
    private readonly ITripRepository _tripRepository;
    private readonly ILoggedUser _loggedUser;

    public CreateActivityUseCase(
        IActivityRepository activityRepository, 
        ITripRepository tripRepository, 
        ILoggedUser loggedUser
    )
    {
        _activityRepository = activityRepository;
        _tripRepository = tripRepository;
        _loggedUser = loggedUser;
    }

    public async Task<ResponseCreateActivityJson> Execute(RequestCreateActivityJson request)
    {
        var user = await _loggedUser.User();

        await Validate(request, user.Id);

        var activity = new Activity
        {
            Name = request.Name,
            Description = request.Description,
            Status = request.Status,
            StartDate = request.StartDate.ToUniversalTime(),
            EndDate = request.EndDate.ToUniversalTime(),
            TripId = request.TripId,
            CreatedAt = DateTime.UtcNow,
        };

        await _activityRepository.AddAsync(activity);

        return new ResponseCreateActivityJson
        {
            Id = activity.Id,
            Name = activity.Name,
            Description = activity.Description,
            StartDate = activity.StartDate,
            EndDate = activity.EndDate,
            Status = activity.Status,
            TripId = activity.TripId,
        };
    }

    private async Task Validate(RequestCreateActivityJson request, Guid userId)
    {
        var validator = new CreateActivityValidator();
        var result = validator.Validate(request);

        var tripExists = await _tripRepository.FindByIdAsync(request.TripId, userId) ?? 
            throw new ResourceNotFoundException(request.TripId.ToString());

        if(request.StartDate > tripExists.EndDate)
        {
            throw new ErrorOnValidationException(new List<string> { ResourceErrorMessages.INVALID_ACTIVITY_START_DATE  });            
        }

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errors);
        }
    }
}
