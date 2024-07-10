using TripPlanner.Communication.Responses.Users;

namespace TripPlanner.Application.UseCases.Users.GetProfile;

public interface IGetUserProfile
{
    Task<ResponseGetUserProfile> Execute();    
}