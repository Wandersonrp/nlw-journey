using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Services.LoggedUser;

public interface ILoggedUser
{
    Task<User> User();    
}