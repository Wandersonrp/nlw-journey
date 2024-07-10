using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Filters;

namespace TripPlanner.API.Attributes;

public class AuthenticatedUserAttribute : TypeFilterAttribute
{
    public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
    {
    }
}