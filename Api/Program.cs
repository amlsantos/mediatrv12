using System.Reflection;
using Application.Behaviours;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;

namespace Api;

internal static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);

        var app = builder.Build();
        Configure(app);

        app.Run();
    }

    private static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;

        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        AddMediatR(services);
    }

    private static void AddMediatR(IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        services.AddMediatR(assemblies);
        services.AddFluentValidation(assemblies);
    }

    private static void Configure(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}