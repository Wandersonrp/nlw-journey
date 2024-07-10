using Microsoft.EntityFrameworkCore;
using TripPlanner.Communication.Enums.Users;
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

        await _context.SaveChangesAsync();
    }

    public Task<bool> ExistsActiveUserWithIdentifier(Guid userIdentifier)
    {
        return _context.Users
            .AsNoTracking()
            .AnyAsync(e => e.Id.Equals(userIdentifier) && e.Status.Equals(Status.Active));
    }

    public async Task<bool> ExistsWithSameEmail(string email)
    {
        return await _context.Users
            .AsNoTracking()
            .Select(e => new User
            {
                Email = e.Email
            })
            .AnyAsync(u => u.Email.Equals(email));
    }

    public async Task<User?> GetByEmailAndPassword(string email, string password)
    {
        var user = await _context.Users
            .AsNoTracking()                        
            .Select(e => new User
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Password = e.Password
            })
            .FirstOrDefaultAsync(e => e.Email.Equals(email) && e.Password.Equals(password));

        return user;    
    }
}
