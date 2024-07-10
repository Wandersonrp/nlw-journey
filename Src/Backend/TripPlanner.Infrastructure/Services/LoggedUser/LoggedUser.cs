using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using TripPlanner.Communication.Enums.Users;
using TripPlanner.Domain.Entities;
using TripPlanner.Domain.Services.Auth;
using TripPlanner.Domain.Services.LoggedUser;
using TripPlanner.Infrastructure.Data.Context;

namespace TripPlanner.Infrastructure.Services.LoggedUser;

public class LoggedUser : ILoggedUser
{
    private readonly TripPlannerDbContext _context;
    private readonly ITokenProvider _tokenProvider;

    public LoggedUser(TripPlannerDbContext context, ITokenProvider tokenProvider)
    {
        _context = context;
        _tokenProvider = tokenProvider;
    }

    public async Task<User> User()
    {
        var token = _tokenProvider.Value();

        var tokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = tokenHandler.ReadJwtToken(token); 

        var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        var parsedIdentifier = Guid.Parse(identifier);

        return await _context.Users
            .AsNoTracking()
            .FirstAsync(e => e.Id.Equals(parsedIdentifier) && e.Status.Equals(Status.Active));
    }
}