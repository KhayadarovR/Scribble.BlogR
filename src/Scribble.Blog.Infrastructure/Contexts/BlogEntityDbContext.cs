using Microsoft.EntityFrameworkCore;
using Scribble.Blog.Models;

namespace Scribble.Blog.Infrastructure.Contexts;

public class BlogEntityDbContext : DbContext
{
    public BlogEntityDbContext(DbContextOptions<BlogEntityDbContext> options) 
        : base(options) { }

    public DbSet<BlogEntity> Blogs { get; set; } = null!;
}