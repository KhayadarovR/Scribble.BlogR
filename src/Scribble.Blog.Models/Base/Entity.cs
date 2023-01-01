namespace Scribble.Blog.Models.Base;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}