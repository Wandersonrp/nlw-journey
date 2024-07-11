using Microsoft.AspNetCore.Mvc;
using TripPlanner.API.Attributes;
using TripPlanner.Application.UseCases.Trips.Create;
using TripPlanner.Application.UseCases.Trips.GetById;
using TripPlanner.Communication.Requests.Trips;
using TripPlanner.Communication.Responses.Trips;

namespace TripPlanner.API.Controllers.Trips;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseCreateTripJson), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ResponseCreateTripJson>> Create(
        [FromBody] RequestCreateTripJson request, [FromServices] ICreateTrip useCase)
    {
        var result = await useCase.Execute(request);

        return CreatedAtAction(nameof(Create), result); 
    }

    [HttpGet("{id}")]
    [AuthenticatedUser]
    [ProducesResponseType(typeof(ResponseCreateTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ResponseGetTripJson>> GetById(
        [FromServices] IGetTripById useCase, 
        [FromRoute] string id
    )
    {
        var result = await useCase.Execute(id);

        return Ok(result);
    }
}
