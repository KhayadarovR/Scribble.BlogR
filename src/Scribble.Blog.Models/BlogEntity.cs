using Scribble.Blog.Models.Base;

namespace Scribble.Blog.Models;

public class BlogEntity : Entity
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}