using System.IO;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Blaztrap.Abstractions;

public static class BzParser
{
    public static string ParseClasess<TTarget>(this TTarget _, params Expression<Func<TTarget>>[] expressions)
        where TTarget : BzControl
    {
        var sb = new StringBuilder();
        foreach (var expression in expressions)
        {
            var targetProperty = ((MemberExpression)expression.Body).Member as PropertyInfo 
                ?? throw new InvalidOperationException("A property is required.");

            var propertyAttributes = targetProperty
                .GetCustomAttributes(false)
                .OfType<BzClassAttribute>();

            foreach (var attribute in propertyAttributes)
            {
                sb.Append($"{attribute.Classes} ");
            }
        }

        return sb.ToString();
    }

    public static Dictionary<string, object> ParseAttributes<TTarget>(this TTarget _, params Expression<Func<TTarget>>[] expressions)
        where TTarget : BzControl
    {
        var attributes = new Dictionary<string, object>();
        foreach (var expression in expressions)
        {
            var targetProperty = ((MemberExpression)expression.Body).Member as PropertyInfo
                ?? throw new InvalidOperationException("A property is required.");

            var propertyAttributes = targetProperty.GetCustomAttributes(false).OfType<BzAttributeAttribute>();
            foreach (var attribute in propertyAttributes)
            {
                attributes.Add(attribute.Name, attribute.Value);
            }
        }

        return attributes;
    }

    public static string ParseClasses(params object[] targets)
    {
        var sb = new StringBuilder();

        foreach (object target in targets)
        {
            if (target is null) continue;
            var targetType = target.GetType();
            var targetField = targetType.GetField(target.ToString()!);
            if (targetField is null) continue;
            var fieldAttributes = targetField.GetCustomAttributes(false).OfType<BzClassAttribute>();

            foreach (var attribute in fieldAttributes)
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
            if(target is null) continue;
            var targetType = target.GetType();
            var targetField = targetType.GetField(target.ToString()!);
            if (targetField is null) continue;
            var fieldAttributes = targetField.GetCustomAttributes(false).OfType<BzAttributeAttribute>();

            foreach (var attribute in fieldAttributes)
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
