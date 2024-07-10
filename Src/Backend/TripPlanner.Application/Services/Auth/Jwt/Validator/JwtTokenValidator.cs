using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using TripPlanner.Domain.Services.Auth;

namespace TripPlanner.Application.Services.Auth.Jwt.Validator;

public class JwtTokenValidator : JwtTokenHandler, IAccessTokenValidator
{
    private string _signingKey;

    public JwtTokenValidator(string signingKey)
    {   
        _signingKey = signingKey;
    }

    public Guid ValidateAndGetUserIdentifier(string token)
    {
        var validationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = SecurityKey(_signingKey),
            ClockSkew = TimeSpan.Zero
        };  

        var tokenHandler = new JwtSecurityTokenHandler();

        var principal = tokenHandler.ValidateToken(token, validationParameters, out _);

        var userIdentifier = principal.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

        return Guid.Parse(userIdentifier);

    }
}