using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Infrastructure.Data.Context;

namespace TripPlanner.Infrastructure.Data.Repositories;

public class ActivityRepository : IActivityRepository
{
    private readonly TripPlannerDbContext _context;

    public ActivityRepository(TripPlannerDbContext context)
    {
        _context = context; 
    }

    public async Task AddAsync(Activity activity)
    {
        await _context.Activities.AddAsync(activity);

        await _context.SaveChangesAsync();
    }
}
