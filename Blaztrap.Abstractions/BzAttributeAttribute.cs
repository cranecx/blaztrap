namespace Blaztrap.Abstractions;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
public class BzAttributeAttribute : Attribute
{
    public string Name { get; set; }
    public string Value { get; set; }

    public BzAttributeAttribute(string name, string value)
    {
        Name = name;
        Value = value;
    }


}
