using TripPlanner.Communication.Responses.Users;
using TripPlanner.Domain.Services.LoggedUser;

namespace TripPlanner.Application.UseCases.Users.GetProfile;

public class GetUserProfileUseCase : IGetUserProfile
{
    private readonly ILoggedUser _loggedUser;

    public GetUserProfileUseCase(ILoggedUser loggedUser)
    {
        _loggedUser = loggedUser;
    }

    public async Task<ResponseGetUserProfile> Execute()
    {
        var user = await _loggedUser.User();

        return new ResponseGetUserProfile
        {
            Email = user.Email,
            Name = user.Name
        };
    }
}