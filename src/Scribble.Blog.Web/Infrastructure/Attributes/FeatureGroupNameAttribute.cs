namespace Scribble.Blog.Web.Infrastructure.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class FeatureGroupNameAttribute : Attribute
{
    public FeatureGroupNameAttribute(string groupName) => 
        GroupName = groupName;
    
    public string GroupName { get; }
}