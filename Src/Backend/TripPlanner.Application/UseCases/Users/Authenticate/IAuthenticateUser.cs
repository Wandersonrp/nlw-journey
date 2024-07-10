using TripPlanner.Communication.Requests.Users;
using TripPlanner.Communication.Responses.Users;

namespace TripPlanner.Application.UseCases.Users.Authenticate;

public interface IAuthenticateUser
{
    Task<ResponseAuthenticateUserJson> Execute(RequestAuthenticateUserJson request);    
}