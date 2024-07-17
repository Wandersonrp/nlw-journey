using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Attributes;
using TripPlanner.Application.UseCases.Activities.Create;
using TripPlanner.Communication.Requests.Activities;
using TripPlanner.Communication.Responses.Activities;

namespace TripPlanner.API.Controllers.Activities;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    [HttpPost]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseCreateActivityJson), StatusCodes.Status201Created)]
    public async Task<ActionResult<ResponseCreateActivityJson>> Create(
        [FromBody] RequestCreateActivityJson request, 
        [FromServices] ICreateActivity useCase
    )
    {
        var result = await useCase.Execute(request);

        return CreatedAtAction(nameof(Create), result); 
    }
}
