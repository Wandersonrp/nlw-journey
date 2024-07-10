using Microsoft.AspNetCore.Mvc;
using TripPlanner.Application.UseCases.Users.Register;
using TripPlanner.Communication.Requests.Users;

namespace TripPlanner.API.Controllers.Users.Register;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Register(
        [FromBody] RequestRegisterUserJson request, 
        [FromServices] IRegisterUser useCase
    )
    {
        await useCase.Execute(request);

        return CreatedAtAction(nameof(Register), string.Empty);
    }
}
