using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Weather.Queries;

public record GetWeatherQuery : IRequest<Result<List<GetWeatherResponse>>>;

public class GetWeatherQueryHandler : IRequestHandler<GetWeatherQuery, Result<List<GetWeatherResponse>>>
{
    private readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public async Task<Result<List<GetWeatherResponse>>> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
    {
        var response = Enumerable.Range(1, 5).Select(index => new GetWeatherResponse
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        
        var result = await Task.FromResult(response);
        return Result.Success(result);
    }
}