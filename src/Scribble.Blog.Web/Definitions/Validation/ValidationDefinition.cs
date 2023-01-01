using Calabonga.AspNetCore.AppDefinitions;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Scribble.Blog.Web.Definitions.Validation;

public class ValidationDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}