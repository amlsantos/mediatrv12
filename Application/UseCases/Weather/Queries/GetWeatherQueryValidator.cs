﻿using FluentValidation;

namespace Application.UseCases.Weather.Queries;

public class GetWeatherQueryValidator : AbstractValidator<GetWeatherQuery>
{
    public GetWeatherQueryValidator()
    {
        // RuleFor(x => x.City).NotNull();
        // RuleFor(x => x.City).NotEmpty();
    }
}