using TripPlanner.Communication.Requests.Users;

namespace TripPlanner.Application.UseCases.Users.Register;

public interface IRegisterUser
{
    Task Execute(RequestRegisterUserJson request);
}
