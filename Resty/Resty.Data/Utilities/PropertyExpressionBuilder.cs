using System.Linq.Expressions;
using System.Reflection;

namespace Resty.Data.Utilities
{
    internal static class PropertyExpressionBuilder
    {
        internal static bool ValidatePropertyAndBuildPropertyExpression(string propertyPath, ParameterExpression parameterExpression, out Expression propertyExpression)
        {
            var propertyType = parameterExpression.Type;
            propertyExpression = parameterExpression;
            foreach (var part in propertyPath.Split('.'))
            {
                var property = propertyType.GetProperty(part, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                if (property == null)
                {
                    return false;
                }
                propertyExpression = Expression.PropertyOrField(propertyExpression, part);
                propertyType = property.PropertyType;
            }

            return true;
        }
    }
}
