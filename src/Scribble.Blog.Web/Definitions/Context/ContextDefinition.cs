using Calabonga.AspNetCore.AppDefinitions;
using Microsoft.EntityFrameworkCore;
using Scribble.Blog.Infrastructure.Contexts;
using Scribble.Blog.Models;

namespace Scribble.Blog.Web.Definitions.Context;

public class ContextDefinition : AppDefinition
{
    public override void ConfigureServices(IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<BlogEntityDbContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
        });



        //
        var connectDB = builder.Configuration.GetConnectionString("Default");

        services.AddTransient<IBlogEntityRepository, BlogRepository>(provider => new BlogRepository(connectDB));
    }
}