using TripPlanner.Domain.Entities;

namespace TripPlanner.Domain.Repositories;

public interface ITripRepository
{
    Task AddAsync(Trip trip);
    Task<Trip?> FindByIdAsync(Guid id);
}