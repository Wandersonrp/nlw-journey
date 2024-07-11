using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using TripPlanner.Communication.Responses;
using TripPlanner.Domain.Repositories;
using TripPlanner.Domain.Services.Auth;
using TripPlanner.Exceptions;
using TripPlanner.Exceptions.ExceptionsBase;

namespace TripPlanner.API.Filters;

public class AuthenticatedUserFilter : IAsyncAuthorizationFilter
{
    private readonly IAccessTokenValidator _accessTokenValidator;
    private readonly IUserRepository _userRepository;

    public AuthenticatedUserFilter(IAccessTokenValidator accessTokenValidator, IUserRepository userRepository)
    {
        _accessTokenValidator = accessTokenValidator;
        _userRepository = userRepository;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        try 
        {
            var token = TokenOnRequest(context);

            var userIdentifier = _accessTokenValidator.ValidateAndGetUserIdentifier(token);

            var userExists = await _userRepository.ExistsActiveUserWithIdentifier(userIdentifier);

            if(!userExists) 
            {
                throw new TripPlannerException(ResourceErrorMessages.USER_WITHOUT_PERMISSION);
            }
        }
        catch(TripPlannerException ex)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson(ex.Message));
        }
        catch(SecurityTokenExpiredException)
        {
            context.Result = new UnauthorizedObjectResult(new ResponseErrorJson("TokenExpired")
            {
                TokenIsExpired = true
            });
        }
        catch
        {
            context.Result = new UnauthorizedObjectResult(ResourceErrorMessages.USER_WITHOUT_PERMISSION);
        }
    }

    private static string TokenOnRequest(AuthorizationFilterContext context) 
    {
        var authentication = context.HttpContext.Request.Headers.Authorization.ToString();

        if(string.IsNullOrWhiteSpace(authentication))
        {
            throw new TripPlannerException(ResourceErrorMessages.MISSING_TOKEN);
        }

        return authentication["Bearer ".Length..].Trim();
    }
}