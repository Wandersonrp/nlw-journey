using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Attributes;
using TripPlanner.Application.UseCases.Users.GetProfile;
using TripPlanner.Communication.Responses.Users;

namespace TripPlanner.API.Controllers.Users.GetUserProfile;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(ResponseGetUserProfile), StatusCodes.Status200OK)]
    [AuthenticatedUser]
    public async Task<ActionResult<ResponseGetUserProfile>> GetProfile([FromServices] IGetUserProfile useCase)
    {
        var result = await useCase.Execute();

        return Ok(result);
    }
}