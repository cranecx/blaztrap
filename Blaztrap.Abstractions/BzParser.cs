using System.Text;

namespace Blaztrap.Abstractions;

public static class BzParser
{
    public static string ParseClasses(params object[] targets)
    {
        var sb = new StringBuilder();

        foreach (object target in targets)
        {
            var targetType = target.GetType();
            var propertyAttributes = targetType.GetProperties()
                .SelectMany(p => p.GetCustomAttributes(false).OfType<BzClassAttribute>());

            var fieldAttributes = targetType.GetFields()
                .SelectMany(f => f.GetCustomAttributes(false).OfType<BzClassAttribute>());

            foreach (var attribute in propertyAttributes.Union(fieldAttributes))
            {
                sb.Append($"{attribute.Classes} ");
            }
        }

        return sb.ToString();
    }

    public static Dictionary<string, object> ParseAttributes(params object[] targets)
    {
        var attributes = new Dictionary<string, object>();

        foreach (object target in targets)
        {
            var targetType = target.GetType();
            var propertyAttributes = targetType.GetProperties()
                .SelectMany(p => p.GetCustomAttributes(false).OfType<BzAttributeAttribute>());

            var fieldAttributes = targetType.GetFields()
                .SelectMany(f => f.GetCustomAttributes(false).OfType<BzAttributeAttribute>());

            foreach (var attribute in propertyAttributes.Union(fieldAttributes))
            {
                attributes.Add(attribute.Name, attribute.Value);
            }
        }

        return attributes;
    }

    public static Dictionary<string, object> ParseAttributes(Dictionary<string, object> existingAttributes, params object[] targets)
    {
        var additional = ParseAttributes(targets);
        var composedAttributes = existingAttributes
            .Concat(additional)
            .ToDictionary(d => d.Key, d => d.Value);

        return composedAttributes;
    }
}
