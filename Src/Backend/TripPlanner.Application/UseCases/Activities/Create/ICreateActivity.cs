using TripPlanner.Communication.Requests.Activities;
using TripPlanner.Communication.Responses.Activities;

namespace TripPlanner.Application.UseCases.Activities.Create;

public interface ICreateActivity
{
    Task<ResponseCreateActivityJson> Execute(RequestCreateActivityJson request);
}
