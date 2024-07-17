using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Repositories;

public interface IActivityRepository
{
    Task AddAsync(Activity activity);
}
