using Microsoft.AspNetCore.Mvc;
using TripPlanner.Application.UseCases.Users.Authenticate;
using TripPlanner.Communication.Requests.Users;
using TripPlanner.Communication.Responses.Users;

namespace TripPlanner.API.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class SigninController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ResponseAuthenticateUserJson>> Sign(
        [FromBody] RequestAuthenticateUserJson reuqest, 
        [FromServices] IAuthenticateUser useCase
    ) 
    {
        var result = await useCase.Execute(reuqest);

        return Ok(result);
    }
}