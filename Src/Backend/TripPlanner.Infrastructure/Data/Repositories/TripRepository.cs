using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Infrastructure.Data.Context;

namespace TripPlanner.Infrastructure.Data.Repositories;

public class TripRepository : ITripRepository
{
    private readonly TripPlannerDbContext _context; 

    public TripRepository(TripPlannerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Trip trip)
    {
        await _context.Trips.AddAsync(trip);

        await _context.SaveChangesAsync();        
    }
}