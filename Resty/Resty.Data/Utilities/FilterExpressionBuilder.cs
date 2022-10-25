using System.Linq.Expressions;
using System.Reflection;
using Resty.Core.Interfaces.Enums.Request;
using Resty.Core.Interfaces.Types.Request;

namespace Resty.Data.Utilities
{
	public static class FilterExpressionBuilder
	{
		private static readonly MethodInfo ContainsMethod = typeof(string).GetMethod(FilterOperator.Contains.ToString(), new[] { typeof(string) });
		private static readonly MethodInfo StartsWithMethod = typeof(string).GetMethod(FilterOperator.StartsWith.ToString(), new[] { typeof(string) });
		private static readonly MethodInfo EndsWithMethod = typeof(string).GetMethod(FilterOperator.EndsWith.ToString(), new[] { typeof(string) });
		
		public static Expression<Func<T, bool>> GetExpression<T>(IEnumerable<IFilter> requestFilters, FilterLogic logic)
		{
			var filters = requestFilters
                ?.Where(x => !string.IsNullOrEmpty(x.Value))
                .ToArray() 
                ?? Array.Empty<IFilter>();
			var expressionParameter = Expression.Parameter(typeof(T), "item");

            Expression resultExpression = null;
            foreach (var filter in filters)
            {
                //var property = typeof(T).GetProperty(filter.Field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                if (PropertyExpressionBuilder.ValidatePropertyAndBuildPropertyExpression(filter.Field, expressionParameter, out var propertyExpression))
                {
                    if (resultExpression == null)
                    {
                        resultExpression = GetExpression(filter.Operator, propertyExpression, filter.Value);
                    }
                    else
                    {
                        resultExpression = (logic == FilterLogic.And)
                            ? Expression.AndAlso(resultExpression, GetExpression(filter.Operator, propertyExpression, filter.Value))
                            : Expression.OrElse(resultExpression, GetExpression(filter.Operator, propertyExpression, filter.Value));
                    }
                }
            }

			return resultExpression == null 
                ? x => true 
                : Expression.Lambda<Func<T, bool>>(resultExpression, expressionParameter);
        }

		private static Expression GetExpression(FilterOperator filterOperator, Expression member, string filterValue)
		{
			ConstantExpression constant;

			if (member.Type == typeof(DateTime) || member.Type == typeof(DateTime?))
			{
				if (filterValue?.IndexOf("GMT") > 0)
				{
					// if filter value is in the nutty javascript format
					// e.g. "Thu Sep 20 2018 00:00:00 GMT-0500 (Central Daylight Time)"
					// strip off the end so that it can be parsed
					filterValue = filterValue.Substring(0, filterValue.IndexOf("GMT", StringComparison.Ordinal)).Trim();
				}

				constant = Expression.Constant(DateTime.Parse(filterValue!), member.Type);
			}
			else if (member.Type == typeof(Guid) || member.Type == typeof(Guid?))
			{
				constant = Expression.Constant(Guid.Parse(filterValue), member.Type);
			}
			else if (member.Type == typeof(int) || member.Type == typeof(int?))
			{
				constant = Expression.Constant(int.Parse(filterValue), member.Type);
			}
			else if (member.Type == typeof(long) || member.Type == typeof(long?))
			{
				constant = Expression.Constant(long.Parse(filterValue), member.Type);
			}
			else if (member.Type == typeof(bool) || member.Type == typeof(bool?))
			{
				constant = Expression.Constant(bool.Parse(filterValue), member.Type);
			}
			else
			{
				constant = Expression.Constant(filterValue, member.Type);
			}

            Expression expression = filterOperator switch
            {
                FilterOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(member, constant),
                FilterOperator.LessThanOrEqual => Expression.LessThanOrEqual(member, constant),
                FilterOperator.LessThan => Expression.LessThan(member, constant),
                FilterOperator.GreaterThan => Expression.GreaterThan(member, constant),
                FilterOperator.Equal => Expression.Equal(member, constant),
                FilterOperator.NotEqual => Expression.NotEqual(member, constant),
                FilterOperator.Contains => Expression.Call(member, ContainsMethod, constant),
                FilterOperator.DoesNotContain => Expression.Not(Expression.Call(member, ContainsMethod, constant)),
                FilterOperator.EndsWith => Expression.Call(member, EndsWithMethod, constant),
                FilterOperator.StartsWith => Expression.Call(member, StartsWithMethod, constant),
                _ => throw new NotImplementedException(
                    $"The \"{filterOperator}\" filter operator has not been implemented.")
            };

            return expression;
		}
	}
}
