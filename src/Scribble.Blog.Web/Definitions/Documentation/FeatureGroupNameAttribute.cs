namespace Scribble.Blog.Web.Definitions.Documentation;

[AttributeUsage(AttributeTargets.Method)]
public class FeatureGroupNameAttribute : Attribute
{
    public FeatureGroupNameAttribute(string groupName) => 
        GroupName = groupName;
    
    public string GroupName { get; }
}