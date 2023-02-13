namespace Blaztrap.Abstractions;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
public class BzClassAttribute : Attribute
{
    public string @Classes { get; }

    public BzClassAttribute(string classes)
    {
        Classes = classes;
    }
}
