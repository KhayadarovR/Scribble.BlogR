using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scribble.Blog.Infrastructure.Contexts;

public class BlogEntityDbContextFactory : IDesignTimeDbContextFactory<BlogEntityDbContext>
{
    public BlogEntityDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BlogEntityDbContext>();
        builder.UseSqlServer(
            "Server=localhost;Database=Scribble.Blog;User Id=sa;Password=du85txss10;TrustServerCertificate=True;Trusted_Connection=True;");
        return new BlogEntityDbContext(builder.Options);
    }
}