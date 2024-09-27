using FinBeatTestExercise.Application.Contracts;
using FinBeatTestExercise.Contracts;
using FinBeatTestExercise.Infrastructure.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FinBeatTestExercise.Infrastructure.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AbstractObjectController(
    IAbstractObjectService service) : ControllerBase
{

    [HttpPost("values")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAbstractObjectsAsync([FromBody] CreateAbstractObjects command)
    {
        var values = command.Values;

        var result = await service.CreateAbstractObjectsAsync(values);

        return result.MatchResult<IActionResult>(
                value => Created(),
                error => BadRequest(error));
    }

    [HttpPost("value")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAbstractObjectAsync([FromBody] CreateAbstractObject command)
    {
        var value = command.Value;

        var result = await service.CreateAbstractObjectAsync(value);

        return result.MatchResult<IActionResult>(
                value => Created(),
                error => BadRequest(error));
    }

    [HttpGet("value")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAbstractObjectAsync([FromQuery] string filter)
    {
        var filters = FilterParser.ParseFilter(filter);

        var result = await service.GetAbstractObjectsByFilterAsync(filters);

        return result.MatchResult<IActionResult>(
                values => Ok(values),
                error => StatusCode((int)error.RelatedStatusCode, error));
    }
}
