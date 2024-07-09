using Microsoft.EntityFrameworkCore;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Repositories;
using TripPlanner.Infrastructure.Data.Context;

namespace TripPlanner.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TripPlannerDbContext _context;

    public UserRepository(TripPlannerDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistsWithSameEmail(string email)
    {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}
