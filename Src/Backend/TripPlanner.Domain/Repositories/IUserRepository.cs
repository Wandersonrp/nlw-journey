using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Repositories;

public interface IUserRepository
{
    Task<bool> ExistsWithSameEmail(string email);
    Task AddAsync(User user);
    Task<User?> GetByEmailAndPassword(string email, string password); 
}
