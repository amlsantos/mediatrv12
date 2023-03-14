using Application.UseCases.Weather.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator) => _mediator = mediator;

    [HttpGet("[action]")]
    public async Task<IActionResult> Get()
    {
        var query = new GetWeatherQuery();

        var result = await _mediator.Send(query);
        return result.IsFailure ? 
            BadRequest(result.Error) : 
            Ok(result.Value);
    }
}