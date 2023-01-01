using Calabonga.AspNetCore.AppDefinitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Scribble.Blog.Web.Infrastructure.Attributes;

namespace Scribble.Blog.Web.Definitions.Swagger;

public class SwaggerDefinition : AppDefinition
{
    private const string ApplicationVersion =
        $"{ThisAssembly.Git.SemVer.Major}.{ThisAssembly.Git.SemVer.Minor}.{ThisAssembly.Git.SemVer.Patch}";

    private const string SwaggerConfig = "/swagger/v1/swagger.json";
        
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Scribble.Blog API",
                Version = ApplicationVersion
            });
            
            options.ResolveConflictingActions(resolver => resolver.First());
            
            options.TagActionsBy(selector =>
            {
                if (selector.ActionDescriptor is { } descriptor)
                {
                    var attribute = descriptor.EndpointMetadata
                        .OfType<FeatureGroupNameAttribute>().FirstOrDefault();

                    return new List<string> 
                    {
                        attribute?.GroupName ?? descriptor.RouteValues["controller"] ?? "Untitled"
                    };
                }

                return !string.IsNullOrEmpty(selector.RelativePath!)
                    ? new List<string> { selector.RelativePath! }
                    : new List<string>();
            });
        });
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(SwaggerConfig, $"Scribble.Blog API v{ApplicationVersion}");
        });
    }
}