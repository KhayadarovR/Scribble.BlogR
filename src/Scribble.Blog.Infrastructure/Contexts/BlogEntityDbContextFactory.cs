using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Scribble.Blog.Infrastructure.Contexts;

public class BlogEntityDbContextFactory : IDesignTimeDbContextFactory<BlogEntityDbContext>
{
    public BlogEntityDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<BlogEntityDbContext>();
        builder.UseSqlServer(
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Scribble.Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        return new BlogEntityDbContext(builder.Options);
    }
}