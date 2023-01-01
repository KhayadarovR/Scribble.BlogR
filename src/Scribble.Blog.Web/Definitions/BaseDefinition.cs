using Calabonga.AspNetCore.AppDefinitions;
using MediatR;

namespace Scribble.Blog.Web.Definitions;

public class BaseDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddLocalization();
        services.AddHttpContextAccessor();
        services.AddResponseCaching();
        services.AddMemoryCache();
        
        services.AddAutoMapper(typeof(Program).Assembly);
        services.AddMediatR(typeof(Program));

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });
        
        services.AddControllers();
    }

    public override void ConfigureApplication(WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapDefaultControllerRoute();
    }
}